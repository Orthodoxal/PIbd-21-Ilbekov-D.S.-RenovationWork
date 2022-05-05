using RenovationWorkBusinessLogic.MailWorker;
using RenovationWorkContracts.BindingModels;
using RenovationWorkContracts.BusinessLogicsContracts;
using RenovationWorkContracts.Enums;
using RenovationWorkContracts.StoragesContracts;
using RenovationWorkContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly IWarehouseStorage _warehouseStorage;
        private readonly AbstractMailWorker _mailWorker;
        private readonly IClientStorage _clientStorage;
        public OrderLogic(IOrderStorage orderStorage, IWarehouseStorage warehouseStorage, AbstractMailWorker mailWorker, IClientStorage clientStorage)
        {
            _orderStorage = orderStorage;
            _warehouseStorage = warehouseStorage;
            _mailWorker = mailWorker;
            _clientStorage = clientStorage;
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }

        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                RepairId = model.RepairId,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Accepted,
                DateCreate = DateTime.Now,
                ClientId = model.ClientId
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = model.ClientId })?.Login,
                Subject = "New order has been created",
                Text = $"Date order: {DateTime.Now}, sum order: {model.Sum}"
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Order is not found");
            }
            if (order.Status != OrderStatus.Accepted && order.Status != OrderStatus.RequiredComponents)
            {
                throw new Exception("Order has not status Accepted or Required components");
            }
            var orderBM = new OrderBindingModel
            {
                Id = order.Id,
                RepairId = order.RepairId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                ClientId = order.ClientId,
                ImplementerId = model.ImplementerId
            };
            try {
                if (_warehouseStorage.SeizureComponents(orderBM))
                {
                    orderBM.Status = OrderStatus.Executing;
                    orderBM.DateImplement = DateTime.Now;
                    _orderStorage.Update(orderBM);
                    _mailWorker.MailSendAsync(new MailSendInfoBindingModel
                    {
                        MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = order.ClientId })?.Login,
                        Subject = $"Changing order status in order №{order.Id}",
                        Text = $"Current status: {OrderStatus.Executing}"
                    });
                }
            }
            catch
            {
                orderBM.Status = OrderStatus.RequiredComponents;
                _orderStorage.Update(orderBM);
            }
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Order is not found");
            }
            if (order.Status != OrderStatus.Executing)
            {
                throw new Exception("Order has not status Executing");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                RepairId = order.RepairId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Ready,
                ClientId = order.ClientId,
                ImplementerId = model.ImplementerId
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = order.ClientId })?.Login,
                Subject = "Changing order status  in order №{order.Id}",
                Text = $"Current status: {OrderStatus.Ready}"
            });
        }

        public void DeliveryOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Order is not found");
            }
            if (order.Status != OrderStatus.Ready)
            {
                throw new Exception("Order has not status Ready");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                RepairId = order.RepairId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Issued,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId
            });
            _mailWorker.MailSendAsync(new MailSendInfoBindingModel
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = order.ClientId })?.Login,
                Subject = "Changing order status  in order №{order.Id}",
                Text = $"Current status: {OrderStatus.Issued}"
            });
        }
    }
}
