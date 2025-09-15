
namespace OOP_SOLID_Principles.ISP_Vehicle
{
    public interface IDrive{
        public void Drive();
    }
    public interface IFly{
    
    }
    public interface ISail{
    
    }

    public class Car:IDrive{
        public void Drive() => Console.WriteLine("Drive");
    }
}
