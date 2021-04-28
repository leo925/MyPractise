using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleB
{
    public class ModuleBModule : IModule
    {
        IRegionManager _regionManager;
        public ModuleBModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("MessageListRegion", typeof(MessageList));
        }

        dynamic f1 = 10;
          
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var r = M(1); 
        }

        public const int MyInt= 10;
        int M(dynamic f1)
        {
            S1 s = new S1
            {
                f1 = 10
            };
            Class1 c = new Class1();

            MyClass mc = new MyClass();
            mc.Compare<int>(1);
            mc.Compare<myColor>(myColor.Green);

            char a = 'a';
            var aa = (int)a;
            var v = DateTime.Now.Date;
            return 1;
        }

        public enum myColor
        {
            Red,Green
        }

        private  struct S1 {
            public int f1;
             static S1() { }
        }

        private class Class1
        {
            public int Age { get; set; }
            public void Method(params int[] i) { }
        }

        public class MyClass
        {
            public void Compare<T>(T val1)
            { }
        }
    }
}
