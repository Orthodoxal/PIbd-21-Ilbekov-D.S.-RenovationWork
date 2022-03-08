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
    public class ComponentStorage : IComponentStorage
    {
        public List<ComponentViewModel> GetFullList()
        {
            using var context = new RenovationWorkDatabase();
            return context.Components.Select(CreateModel).ToList();
        }

        public List<ComponentViewModel> GetFilteredList(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new RenovationWorkDatabase();
            return context.Components
            .Where(rec => rec.ComponentName.Contains(model.ComponentName))
            .Select(CreateModel)
            .ToList();
        }
        public ComponentViewModel GetElement(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new RenovationWorkDatabase();
            var component = context.Components
            .FirstOrDefault(rec => rec.ComponentName == model.ComponentName || rec.Id
           == model.Id);
            return component != null ? CreateModel(component) : null;
        }
        public void Insert(ComponentBindingModel model)
        {
            using var context = new RenovationWorkDatabase();
            context.Components.Add(CreateModel(model, new Component()));
            context.SaveChanges();
        }

        public void Update(ComponentBindingModel model)
        {
            using var context = new RenovationWorkDatabase();
            var element = context.Components.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Element is not found");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(ComponentBindingModel model)
        {
            using var context = new RenovationWorkDatabase();
            Component element = context.Components.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Components.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Element is not found");
            }

        }
        private static Component CreateModel(ComponentBindingModel model, Component
       component)
        {
            component.ComponentName = model.ComponentName;
            return component;
        }
        private ComponentViewModel CreateModel(Component component)
        {
            return new ComponentViewModel
            {
                Id = component.Id,
                ComponentName = component.ComponentName
            };
        }
    }
}
