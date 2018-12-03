using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using SilverlightPractiseInfrastructure;
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

namespace SilverlightPractise
{
    public class ShellViewModel
    {
        private readonly IRegionManager _regionManager;
        public DelegateCommand<object> NaviateCommand { get;private set; }

        public ShellViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NaviateCommand = new DelegateCommand<object>(Navigate);
            ApplicationCommands.NavigateCommand.RegisterCommand(NaviateCommand);

        }

        private void Navigate(object obj)
        {
            if (true)
                _regionManager.RequestNavigate(RegionNames.ContentRegion, obj.ToString());
        }
    }
}
