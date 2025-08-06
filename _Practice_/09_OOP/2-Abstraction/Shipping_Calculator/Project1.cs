
using System.Threading.Channels;

namespace OOP_Abstraction.Shipping_Calculator
{
    public abstract class Shipping{
        public abstract int ShippingCost(int value);
    }

    public class StandardShipping : Shipping{
        public override int ShippingCost(int value) => value - (value * 20/100) ;
    }

    public class ExpressShipping : Shipping{
        public override int ShippingCost(int value) => value - (value * 25 / 100);
    }
}
