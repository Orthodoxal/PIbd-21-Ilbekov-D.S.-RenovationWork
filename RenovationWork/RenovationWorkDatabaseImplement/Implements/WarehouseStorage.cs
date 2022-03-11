using Microsoft.EntityFrameworkCore;
using RenovationWorkContracts.BindingModels;
using RenovationWorkContracts.StoragesContracts;
using RenovationWorkContracts.ViewModels;
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
            return context.Repairs
            .Include(rec => rec.RepairComponents)
            .ThenInclude(rec => rec.Component)
            .Where(rec => rec.RepairName.Contains(model.RepairName))
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
            var repair = context.Repairs
            .Include(rec => rec.RepairComponents)
            .ThenInclude(rec => rec.Component)
            .FirstOrDefault(rec => rec.RepairName == model.RepairName ||
            rec.Id == model.Id);
            return repair != null ? CreateModel(repair) : null;
        }
        public void Insert(WarehouseBindingModel model)
        {
            using var context = new RenovationWorkDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                CreateModel(model, new Repair(), context);
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
                var element = context.Repairs.FirstOrDefault(rec => rec.Id ==
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
            Repair element = context.Repairs.FirstOrDefault(rec => rec.Id ==
            model.Id);
            if (element != null)
            {
                context.Repairs.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Element is not found");
            }
        }
        private static Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse)
        {
            repair.RepairName = model.RepairName;
            repair.Price = model.Price;

            if (model.Id.HasValue)
            {
                var productComponents = context.RepairComponents.Where(rec =>
               rec.RepairId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.RepairComponents.RemoveRange(productComponents.Where(rec =>
               !model.RepairComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in productComponents)
                {
                    updateComponent.Count =
                   model.RepairComponents[updateComponent.ComponentId].Item2;
                    model.RepairComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            else
            {
                context.Repairs.Add(repair);
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.RepairComponents)
            {
                context.RepairComponents.Add(new RepairComponent
                {
                    RepairId = repair.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return repair;
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
                ToDictionary(recRC => recRC.Key, recRC => (source.Components.
                    FirstOrDefault(recC => recC.Id == recRC.Key)?.ComponentName, recRC.Value))
            };
        }

        public bool SeizureComponents(OrderBindingModel model)
        {
            var listRepairComponent = source.Repairs.FirstOrDefault(rec => rec.Id == model.RepairId).RepairComponents;
            //проверка наличия компонентов
            foreach (var comp in listRepairComponent)
            {
                //количество компонента необходимое для заказа
                int amountComp = comp.Value * model.Count;
                foreach (var warehouse in source.Warehouses.Where(rec => rec.WarehouseComponents.ContainsKey(comp.Key)))
                {
                    amountComp -= warehouse.WarehouseComponents[comp.Key];
                    if (amountComp <= 0)
                    {
                        break;
                    }
                }
                if (amountComp > 0)
                {
                    return false;
                }
            }
            //операция списания компонентов
            foreach (var comp in listRepairComponent)
            {
                //количество компонента необходимое для заказа
                int amountComp = comp.Value * model.Count;
                foreach (var warehouse in source.Warehouses.Where(rec => rec.WarehouseComponents.ContainsKey(comp.Key)))
                {
                    if (warehouse.WarehouseComponents[comp.Key] >= amountComp)
                    {
                        warehouse.WarehouseComponents[comp.Key] -= amountComp;
                        break;
                    }
                    else
                    {
                        amountComp -= warehouse.WarehouseComponents[comp.Key];
                        warehouse.WarehouseComponents[comp.Key] = 0;
                    }
                }
            }
            return true;
        }
    }
}
