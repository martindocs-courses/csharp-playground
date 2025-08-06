
namespace OOP_Inheritance.Sensor_System
{
    public class Sensor{
        protected string Reading { get; set; }

        public string GetReading() => Reading;
        protected void SetReading(string value) => Reading = value; // only visible to inherited subclass
    }

    public class TemperatureSensor : Sensor {
    
       public void AddTemperature(string unit){
            SetReading(unit);
            Console.WriteLine(GetReading());
       }        
    }
}
