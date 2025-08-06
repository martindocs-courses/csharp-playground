
namespace OOP_Encapsulation.Termostat
{
    public class Termostat
    {
        private int _temperature;

        public void SetTemperature(){

            while (true) {
                int temp = InputValidator("Set the temperature between 10°C and 30°C: ");
            
                if(temp >= 10 && temp <=30){
                    _temperature = temp;
                    Console.WriteLine("New temperature set!");
                    Console.WriteLine($"Now the temperature is {CurrentTemperature(_temperature)}°C");
                    return;
                }else{
                    Console.WriteLine("The value is not between bounds!");
                }
            }
        }

        public int CurrentTemperature(int current_temp) => current_temp;

        public int InputValidator(string text)
        {
            while (true)
            {
                Console.Write(text);
                string? input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("\nText cannot be empty!\n");
                }
            }
        }

    }
}
