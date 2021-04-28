using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using Module1;
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
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.RootVisual = (Page)Shell;
           
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            Type moduleAType = typeof(ModuleA);
            ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleAType.Name,
                ModuleType = moduleAType.AssemblyQualifiedName,
                 InitializationMode=  InitializationMode.WhenAvailable
            });

           


        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return base.CreateModuleCatalog();
        //}
    }
}
