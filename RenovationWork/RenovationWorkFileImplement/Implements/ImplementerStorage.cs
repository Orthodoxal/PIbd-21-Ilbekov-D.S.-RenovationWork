using RenovationWorkContracts.BindingModels;
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
    public class ImplementerStorage : IImplementerStorage
    {
        private readonly FileDataListSingleton source;
        public ImplementerStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<ImplementerViewModel> GetFullList()
        {
            return source.Implementers.Select(CreateModel).ToList();
        }
        public List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Implementers.Where(rec => rec.Fullname == model.Fullname).Select(CreateModel).ToList();
        }
        public ImplementerViewModel GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var implementer = source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            return implementer != null ? CreateModel(implementer) : null;
        }
        public void Insert(ImplementerBindingModel model)
        {
            int maxId = source.Implementers.Count > 0 ? source.Implementers.Max(rec =>
                rec.Id) : 0;
            var element = new Implementer { Id = maxId + 1 };
            source.Implementers.Add(CreateModel(model, element));
        }
        public void Update(ImplementerBindingModel model)
        {
            var element = source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Implementer not found");
            }
            CreateModel(model, element);
        }
        public void Delete(ImplementerBindingModel model)
        {
            Implementer element = source.Implementers.FirstOrDefault(rec => rec.Id ==
                model.Id);
            if (element != null)
            {
                source.Implementers.Remove(element);
            }
            else
            {
                throw new Exception("Implementer not found");
            }
        }
        private static Implementer CreateModel(ImplementerBindingModel model, Implementer
            implementer)
        {
            implementer.Fullname = model.Fullname;
            implementer.PauseTime = model.PauseTime;
            implementer.WorkingTime = model.WorkingTime;
            return implementer;
        }
        private ImplementerViewModel CreateModel(Implementer implementer)
        {
            return new ImplementerViewModel
            {
                Id = implementer.Id,
                Fullname = implementer.Fullname,
                WorkingTime = implementer.WorkingTime,
                PauseTime = implementer.PauseTime
            };
        }
    }
}
