using RenovationWorkContracts.BindingModels;
using RenovationWorkContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenovationWorkContracts.BusinessLogicsContracts
{
    public interface IMessageInfoLogic
    {
        List<MessageInfoViewModel> Read(MessageInfoBindingModel model);
        void CreateOrUpdate(MessageInfoBindingModel model);
    }
}
