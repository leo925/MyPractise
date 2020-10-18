using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class CustomVMConnectionViewModel:BindableBase
    {
        private string title= "this is from CustomVMConnectionViewModel";

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

    }
}
