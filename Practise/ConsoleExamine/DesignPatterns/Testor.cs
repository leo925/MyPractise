﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamine
{
    public class DesignPatternTestor
    {
        public void TestSingleton()
        {
            LogHelper.Instance.Write();
        }

        public void TestFactoryMethod()
        {
            LogFactory fac = new XmlLogFactory();
            logger logger = fac.CreateLogger();

            logger.log();
        }

        public void TestAbstractFactory()
        {
            AbstractHouseFacotry fac = new EuropeanHouseFacotry(); ;
            BaseFloor floor = fac.CreateFloor();
            BaseWall wall = fac.CreateWall();
        }

        public void TestAdapter()
        {
            new CompositeNewWorker().DoWork("aa");

            new InheritNewWork().DoWork("bb");
        }
    }
}
