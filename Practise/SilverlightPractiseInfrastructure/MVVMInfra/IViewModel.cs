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

namespace SilverlightPractiseInfrastructure.MVVMInfra
{
    public interface IViewModel
    {
        IView View{ get; set; }
    }

    public interface IView
    {
        IViewModel ViewModel{get;set;}
    }


}
