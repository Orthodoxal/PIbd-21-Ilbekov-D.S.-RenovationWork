﻿using RenovationWorkContracts.BindingModels;
using RenovationWorkContracts.BusinessLogicsContracts;
using RenovationWorkContracts.Enums;
using RenovationWorkContracts.ViewModels;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RenovationWorkBusinessLogic.BusinessLogics
{
    public class WorkModeling : IWorkProcess
    {
        private IOrderLogic orderLogic;
        private readonly Random rnd;
        public WorkModeling()
        {
            rnd = new Random(1000);
        }
        public void DoWork(IImplementerLogic implementerLogic, IOrderLogic orderLogic)
        {
            this.orderLogic = orderLogic;
            var implementers = implementerLogic.Read(null);
            ConcurrentBag<OrderViewModel> orders = new(this.orderLogic.Read(new OrderBindingModel
            {
                SearchStatus = OrderStatus.Accepted
            }));
            foreach (var implementer in implementers)
            {
                Task.Run(async () => await WorkerWorkAsync(implementer, orders));
            }
        }
        private async Task WorkerWorkAsync(ImplementerViewModel implementer, ConcurrentBag<OrderViewModel> orders)
        {
            var runOrders = await Task.Run(() => orderLogic.Read(new OrderBindingModel
            {
                ImplementerId = implementer.Id,
                Status = OrderStatus.Executing
            }));
            foreach (var order in runOrders)
            {
                Thread.Sleep(implementer.WorkingTime * 100 * rnd.Next(1, 5) * order.Count);
                orderLogic.FinishOrder(new ChangeStatusBindingModel
                {
                    OrderId = order.Id
                });
                Thread.Sleep(implementer.PauseTime * 100);
            }

            var requiredComponentsOrders = await Task.Run(() => orderLogic.Read(new OrderBindingModel
            {
                ImplementerId = implementer.Id,
                Status = OrderStatus.RequiredComponents
            }));
            foreach (var order in requiredComponentsOrders)
            {
                orderLogic.TakeOrderInWork(new ChangeStatusBindingModel
                {
                    OrderId = order.Id,
                    ImplementerId = implementer.Id
                });
                OrderViewModel tempOrder = orderLogic.Read(new OrderBindingModel { Id = order.Id })?[0];
                if (tempOrder.Status == OrderStatus.RequiredComponents)
                {
                    continue;
                }
                Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                orderLogic.FinishOrder(new ChangeStatusBindingModel
                {
                    OrderId = order.Id,
                    ImplementerId = implementer.Id
                });
                Thread.Sleep(implementer.PauseTime);
            }

            await Task.Run(() =>
            {
                while (!orders.IsEmpty)
                {
                    if (orders.TryTake(out OrderViewModel order))
                    {
                        orderLogic.TakeOrderInWork(new ChangeStatusBindingModel
                        {
                            OrderId = order.Id,
                            ImplementerId = implementer.Id
                        });
                        OrderViewModel isRequiredOrder = orderLogic.Read(new OrderBindingModel { Id = order.Id })?[0];
                        if (isRequiredOrder.Status == OrderStatus.RequiredComponents)
                        {
                            continue;
                        }
                        Thread.Sleep(implementer.WorkingTime * 100 * rnd.Next(1, 5) * order.Count);
                        orderLogic.FinishOrder(new ChangeStatusBindingModel
                        {
                            OrderId = order.Id,
                            ImplementerId = implementer.Id
                        });
                        Thread.Sleep(implementer.PauseTime * 100);
                    }
                }
            });
        }
    }
}
