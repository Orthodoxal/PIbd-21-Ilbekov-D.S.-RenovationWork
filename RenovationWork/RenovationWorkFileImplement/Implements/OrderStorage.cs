﻿using RenovationWorkContracts.BindingModels;
using RenovationWorkContracts.StoragesContracts;
using RenovationWorkContracts.ViewModels;
using RenovationWorkFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkFileImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly FileDataListSingleton source;

        public OrderStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<OrderViewModel> GetFullList()
        {
            return source.Orders.Select(CreateModel).ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Orders.Where(rec => rec.RepairId == model.RepairId
            || (rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo)
            || (model.ClientId.HasValue && rec.ClientId == model.ClientId.Value)
            || (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && model.Status == rec.Status))
                .Select(CreateModel)
                .ToList();
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }

        public void Insert(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ?
                 source.Orders.Max(rec => rec.Id) : 0;
            var element = new Order { Id = maxId + 1 };
            source.Orders.Add(CreateModel(model, element));
        }

        public void Update(OrderBindingModel model)
        {
            var element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Element is not found");
            }
            CreateModel(model, element);
        }

        public void Delete(OrderBindingModel model)
        {
            Order element = source.Orders.
               FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Orders.Remove(element);
            }
            else
            {
                throw new Exception("Element is not found");
            }
        }

        private static Order CreateModel(OrderBindingModel model, Order order)
        {
            order.RepairId = model.RepairId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.ClientId = model.ClientId.Value;
            order.ImplementerId = model.ImplementerId;
            return order;
        }

        private OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                RepairId = order.RepairId,
                ClientId = order.ClientId,
                ClientFullname = source.Clients.FirstOrDefault(rec => rec.Id == order.ClientId)?.Fullname,
                RepairName = source.Repairs.FirstOrDefault(rec => rec.Id == order.RepairId)?.RepairName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                ImplementerId = order.ImplementerId,
                ImplementerFullname = source.Implementers.FirstOrDefault(rec => rec.Id == order.ImplementerId)?.Fullname
            };
        }
    }
}
