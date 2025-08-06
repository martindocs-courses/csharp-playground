
namespace OOP_Inheritance.Vehicle.Maintenance.Log
{
    public class Vehicle{
        // exposing access through explicit SetMileage and SetLastServiceDate methods, so there's no need for private properties
        private int _mileage;
        private DateTime _lastServiceDate;

        public void GetServiceInfo(){
            Console.WriteLine($"Mileage: {_mileage}, Last Service Date: {_lastServiceDate}");
        } 

        protected void SetMileage(int mileage) => _mileage = mileage;
        protected void SetLastServiceDate(DateTime serviceDate) => _lastServiceDate = serviceDate;
    }

    public class ElectricVehicle : Vehicle{

        private int _batteryHealth;
        public void CheckBattery(){

            Console.WriteLine($"Battery Health: {_batteryHealth}%");
        }

        public void MaintenanceLog(int milage, DateTime serviceDate, int batteryHealth){
            Console.WriteLine("Car Service check:");
            SetMileage(milage);
            SetLastServiceDate(serviceDate);
            _batteryHealth = batteryHealth;

            GetServiceInfo();
            CheckBattery();
        }
    }

}
