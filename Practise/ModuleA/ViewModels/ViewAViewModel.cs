using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        public ViewAViewModel() {
            ClickCommand = new DelegateCommand(Click, CanClick);
        }

        private bool CanClick()
        {
            return CanExecute;
        }

        private void Click()
        {
            this.Title = "you clicked me";
        }

        private bool canExecute=true;

        public bool CanExecute
        {
            get { return canExecute; }
            set { SetProperty(ref canExecute, value);
                this.ClickCommand.RaiseCanExecuteChanged();
            }
        }


        private string _title = "Hello this is from view model.";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DelegateCommand clickCommand;

        public DelegateCommand ClickCommand
        {
            get { return clickCommand; }
            set { clickCommand = value; }
        }



    }
} 
