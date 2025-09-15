
namespace OOP_SOLID_Principles.LSP_Flaying_Birds
{
     public abstract class Employee{
        
        private double salary { get; set; }

        public double Salary{
            get{ return salary; }
            set{ salary = value; }
        }

        public abstract void CalculateSalary();

        // If you want to allow subclasses to optionally change the behavior of a method, you make it virtual.
        public virtual void CalculateBenefits(){}
    }

    public class FullTimeEmployee : Employee
    {       
        public override void CalculateSalary()
        {
            Salary = 100;
            Console.WriteLine($"Calculate Full Time Employee salary.{Salary}");
        }
        public void CalculateBenefits()
        {
            Console.WriteLine("Calculate Employee Benefit");
        }
    }

    public class Contractor : Employee
    {        
        public override void CalculateSalary()
        {
            Salary = 500;
            Console.WriteLine($"Calculate Contactor salary.{Salary}");
        }
    }

    public class Calculate{
    
        public void Process(Employee em){
            Console.WriteLine(em.CalculateBenefits);
            Console.WriteLine(em.CalculateSalary);
        }
    
    } 

    
}
