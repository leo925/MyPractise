using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public ModuleAModule(IRegionManager regionManager) {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            /*view discovery
            //discovery, with discovery , have no control over creating the view.
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
                */

            ////view injection
            //IRegion region = _regionManager.Regions["MessageInputRegion"];
            //var view1 = containerProvider.Resolve<MessageInput>();
            //region.Add(view1);

            _regionManager.RegisterViewWithRegion("MessageInputRegion", typeof(MessageInput));

            //var view2 = containerProvider.Resolve<ViewA>();
            //view2.Content = new TextBlock() {
            //    Text= "hello from view 2"
            //};
            //region.Add(view2);
            //region.Activate(view2);


        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
