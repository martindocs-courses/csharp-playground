
namespace OOP_SOLID_Principles.ISP_Printer
{
    public interface IPrinter{
        public void Print();
    }
    public interface IScanner{
        public void Scan();
    }
    public interface IFax{
        public void Fax();
    }

    public class OldPrinter : IPrinter
    {
        public void Print() => Console.WriteLine("Print");
    }

}
