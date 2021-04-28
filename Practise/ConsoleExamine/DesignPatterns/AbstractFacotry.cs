using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamine
{
    public abstract class AbstractHouseFacotry
    {
        public abstract BaseWall CreateWall();
        public abstract BaseFloor CreateFloor();
    }

    public class EuropeanHouseFacotry : AbstractHouseFacotry
    {
        public override BaseFloor CreateFloor()
        {
            return new EuropeanFloor();
        }

        public override BaseWall CreateWall()
        {
            return new EuropeanWall();
        }
    }

    public abstract class BaseWall
    {

    }

    public class EuropeanWall : BaseWall
    {
    }

    public class AsianWall : BaseWall
    {
    }


    public abstract class BaseFloor
    {

    }

    public class EuropeanFloor : BaseFloor
    {
    }

    public class AsianFloor : BaseFloor
    {
    }


}
