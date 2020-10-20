using ModuleA;
using ModuleA.ViewModels;
using ModuleA.Views;
using ModuleB;
using ModuleB.ViewModels;
using ModuleB.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
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
            //containerRegistry.RegisterSingleton<IClass, ClassA>();


            ViewModelLocationProvider.Register<MessageInput, MessageInputViewModel>();

            ViewModelLocationProvider.Register<MessageList, MessagesViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleAModule>(  );

            moduleCatalog.AddModule<ModuleBModule>( );
        }

        protected override void ConfigureViewModelLocator()
        {
            /*
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.Register<ViewA, CustomVMConnectionViewModel>();
            */

            //ViewModelLocationProvider.Register<MessageInput>(()=>
            //{
            //    return new MessageInputViewModel()
            //    {
                    
            //    };
            //});


        }

    }
}
