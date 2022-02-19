using RenovationWorkContracts.BindingModels;
using RenovationWorkContracts.BusinessLogicsContracts;
using RenovationWorkContracts.StoragesContracts;
using RenovationWorkContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkBusinessLogic.BusinessLogics
{
    public class WarehouseLogic : IWarehouseLogic
    {
        private readonly IWarehouseStorage _warehouseStorage;
        private readonly IComponentStorage _componentStorage;

        public WarehouseLogic(IWarehouseStorage warehouseStorage, IComponentStorage componentStorage)
        {
            _warehouseStorage = warehouseStorage;
            _componentStorage = componentStorage;
        }

        public List<WarehouseViewModel> Read(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return _warehouseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<WarehouseViewModel> { _warehouseStorage.GetElement(model) };
            }
            return _warehouseStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(WarehouseBindingModel model)
        {
            var element = _warehouseStorage.GetElement(new WarehouseBindingModel
            {
                WarehouseName = model.WarehouseName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("There is already a warehouse with the same name");
            }
            if (model.Id.HasValue)
            {
                _warehouseStorage.Update(model);
            }
            else
            {
                _warehouseStorage.Insert(model);
            }
        }

        public void Delete(WarehouseBindingModel model)
        {
            var element = _warehouseStorage.GetElement(new WarehouseBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Element is not found");
            }
            _warehouseStorage.Delete(model);
        }

        public void AddComponent(WarehouseBindingModel warehouseModel, ComponentBindingModel componentModel, int Amount)
        {
            var warehouse = _warehouseStorage.GetElement(new WarehouseBindingModel { Id = warehouseModel.Id });
            var component = _componentStorage.GetElement(new ComponentBindingModel { Id = componentModel.Id });
            if (warehouse == null)
            {
                throw new Exception("Element is not found");
            }
            if (component == null)
            {
                throw new Exception("Element is not found");
            }
            if (warehouse.WarehouseComponents.ContainsKey((int)componentModel.Id))
            {
                warehouse.WarehouseComponents[(int)componentModel.Id] =
                    (component.ComponentName, warehouse.WarehouseComponents[(int)componentModel.Id].Item2 + Amount);
            }
            else
            {
                warehouse.WarehouseComponents.Add((int)componentModel.Id, (component.ComponentName, Amount));
            }
            _warehouseStorage.Update(new WarehouseBindingModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                ResponsibleFullName = warehouse.ResponsibleFullName,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouse.WarehouseComponents
            });
        }
    }
}
