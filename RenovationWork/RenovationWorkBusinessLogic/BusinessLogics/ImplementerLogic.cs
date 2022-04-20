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
    public class ImplementerLogic : IImplementerLogic
    {
        private readonly IImplementerStorage implementerStorage;
        public ImplementerLogic(IImplementerStorage implementerStorage)
        {
            this.implementerStorage = implementerStorage;
        }
        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return implementerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ImplementerViewModel> { implementerStorage.GetElement(model) };
            }
            return implementerStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            var element = implementerStorage.GetElement(new ImplementerBindingModel { Fullname = model.Fullname });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("There is already a implementer with the same Fullname");
            }
            if (model.Id.HasValue)
            {
                implementerStorage.Update(model);
            }
            else
            {
                implementerStorage.Insert(model);
            }
        }
        public void Delete(ImplementerBindingModel model)
        {
            var element = implementerStorage.GetElement(new ImplementerBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Element is not found");
            }
            implementerStorage.Delete(model);
        }
    }
}
