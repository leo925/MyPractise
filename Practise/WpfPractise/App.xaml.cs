using ModuleA;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Windows;
using WpfPractise.Views;

namespace WpfPractise
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            //DI container in this case dry IOC used to resolve the instance
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleAModule>( InitializationMode.WhenAvailable);
        }

    }
}
