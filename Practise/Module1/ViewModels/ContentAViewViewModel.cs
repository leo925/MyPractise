using SilverlightPractiseInfrastructure.MVVMInfra;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Module1.ViewModels
{
    public class ContentAViewViewModel : IContentAViewModel
    {

        public ContentAViewViewModel(IContentAView view)
        {
            View = view;
            View.ViewModel = this;
        }

        //public ContentAViewViewModel()
        //{
        //}
        public IView View
        {
            get; set;
        }

        private string message;

        public string Message
        {
            get { return "mesage for a from view model"; }
            set { message = value; }
        }

    }
}
