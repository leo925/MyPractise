using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Module1.ViewModels;
using SilverlightPractiseInfrastructure;
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

namespace Module1
{
    public class ModuleA : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public ModuleA(IRegionManager regionManager,IUnityContainer container )
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {

            _regionManager.RegisterViewWithRegion(RegionNames.HeaderRegionName, typeof(HeaderView));
            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ViewA));


            _container.RegisterType<IContentAView, ViewA>();
            _container.RegisterType<IContentAViewModel, ContentAViewViewModel>();


            var vm = _container.Resolve<IContentAViewModel>();
            var region = _regionManager.Regions[RegionNames.ContentRegion];
            region.Add(vm.View);
           



        }
    }
}
