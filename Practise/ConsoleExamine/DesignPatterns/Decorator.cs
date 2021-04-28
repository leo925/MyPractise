using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamine
{
    class Decorator
    {
    }

    public class House//this should be a base abstract house
    {
        public void Decorate()
        {
            //docorate the house
        }
    }

    public abstract class HouseDecorator
    {
        private House house;

        public HouseDecorator(House house)
        {
            this.house = house;
        }

        public virtual void Decorate()
        {
            house.Decorate();
        }
    }

    public class ChildrenHouseDecorator : HouseDecorator
    {
        public ChildrenHouseDecorator(House house):base(house)
        {
        }
        public override void Decorate()
        {
            base.Decorate();
            //add some toys into the house
        }
    }

    public class AdultHouseDecorator : HouseDecorator
    {
        public AdultHouseDecorator(House house):base(house)
        {
        }
        public override void Decorate()
        {
            base.Decorate();
            //add some ornaments into the 
        }
    }



}
