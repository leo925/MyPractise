using SilverlightPractiseInfrastructure.MVVMInfra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Module1
{
    public partial class ViewA : UserControl,IContentAView
    {
        //public ViewA(IContentAViewModel vm)
        //{
        //    InitializeComponent();
        //    ViewModel = vm;
        //}

        public ViewA()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get
            {
                return (IContentAViewModel)DataContext;
            }

            set
            {
                DataContext = value;
            }
        }
    }
}
