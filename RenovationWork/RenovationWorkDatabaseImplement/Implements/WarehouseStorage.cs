using Microsoft.EntityFrameworkCore;
using RenovationWorkContracts.BindingModels;
using RenovationWorkContracts.StoragesContracts;
using RenovationWorkContracts.ViewModels;
using RenovationWorkDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkDatabaseImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        public List<WarehouseViewModel> GetFullList()
        {
            using var context = new RenovationWorkDatabase();
            return context.Warehouses
            .Include(rec => rec.WarehouseComponents)
            .ThenInclude(rec => rec.Component)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new RenovationWorkDatabase();
            return context.Warehouses
            .Include(rec => rec.WarehouseComponents)
            .ThenInclude(rec => rec.Component)
            .Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new RenovationWorkDatabase();
            var warehouse = context.Warehouses
            .Include(rec => rec.WarehouseComponents)
            .ThenInclude(rec => rec.Component)
            .FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName ||
            rec.Id == model.Id);
            return warehouse != null ? CreateModel(warehouse) : null;
        }
        public void Insert(WarehouseBindingModel model)
        {
            using var context = new RenovationWorkDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                CreateModel(model, new Warehouse(), context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(WarehouseBindingModel model)
        {
            using var context = new RenovationWorkDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Warehouses.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Element is not found");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(WarehouseBindingModel model)
        {
            using var context = new RenovationWorkDatabase();
            Warehouse element = context.Warehouses.FirstOrDefault(rec => rec.Id ==
            model.Id);
            if (element != null)
            {
                context.Warehouses.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Element is not found");
            }
        }
        private static Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse, RenovationWorkDatabase context)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.ResponsibleFullName = model.ResponsibleFullName;
            warehouse.DateCreate = model.DateCreate;

            if (model.Id.HasValue)
            {
                var warehouseComponents = context.WarehouseComponents.Where(rec =>
               rec.WarehouseId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.WarehouseComponents.RemoveRange(warehouseComponents.Where(rec =>
               !model.WarehouseComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in warehouseComponents)
                {
                    updateComponent.Count =
                   model.WarehouseComponents[updateComponent.ComponentId].Item2;
                    model.WarehouseComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            else
            {
                context.Warehouses.Add(warehouse);
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.WarehouseComponents)
            {
                context.WarehouseComponents.Add(new WarehouseComponent
                {
                    WarehouseId = warehouse.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return warehouse;
        }
        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                ResponsibleFullName = warehouse.ResponsibleFullName,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouse.WarehouseComponents.
                    ToDictionary(recPC => recPC.ComponentId,
                    recPC => (recPC.Component?.ComponentName, recPC.Count))
            };
        }

        public bool SeizureComponents(OrderBindingModel model)
        {
            using var context = new RenovationWorkDatabase();                   
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var listRepairComponent = context.RepairComponents.Where(rec => rec.RepairId == model.RepairId);
                    //операция списания компонентов
                    foreach (var comp in listRepairComponent)
                    {
                        //количество компонента необходимое для заказа
                        int amountCompRepair = comp.Count * model.Count;
                        foreach (var warehouseComponents in context.WarehouseComponents.Where(rec => rec.ComponentId == comp.ComponentId))
                        {
                            if (warehouseComponents.Count > amountCompRepair)
                            {
                                warehouseComponents.Count -= amountCompRepair;
                                amountCompRepair = 0;
                                break;
                            }
                            else
                            {
                                amountCompRepair -= warehouseComponents.Count;
                                warehouseComponents.Count = 0;
                            }
                        }
                        if (amountCompRepair != 0)
                        {
                            throw new Exception("Not enough components");
                        }
                    }
                    context.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
