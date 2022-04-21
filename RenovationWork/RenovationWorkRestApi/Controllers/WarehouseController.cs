using Microsoft.AspNetCore.Mvc;
using RenovationWorkContracts.BindingModels;
using RenovationWorkContracts.BusinessLogicsContracts;
using RenovationWorkContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenovationWorkRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseLogic _warehouseLogic;
        private readonly IComponentLogic _componentLogic;
        public WarehouseController(IWarehouseLogic warehouseLogic, IComponentLogic componentLogic)
        {
            _warehouseLogic = warehouseLogic;
            _componentLogic = componentLogic;
        }
        [HttpGet]
        public List<WarehouseViewModel> GetWarehouseList() => _warehouseLogic.Read(null)?.ToList();
        [HttpGet]
        public WarehouseViewModel GetWarehouse(int warehouseId) => _warehouseLogic.Read(new WarehouseBindingModel { Id = warehouseId })?[0];
        [HttpGet]
        public List<ComponentViewModel> GetComponentsList() => _componentLogic.Read(null)?.ToList();
        [HttpPost]
        public void CreateUpdateWarehouse(WarehouseBindingModel model) => _warehouseLogic.CreateOrUpdate(model);
        [HttpPost]
        public void DeleteWarehouse(WarehouseBindingModel model) => _warehouseLogic.Delete(model);
        [HttpPost]
        public void AddComponentWarehouse(WarehouseAddComponentBindingModel model) =>
            _warehouseLogic.AddComponent(new WarehouseBindingModel { Id = model.WarehouseId }, new ComponentBindingModel { Id = model.ComponentId }, model.Count);
    }
}
