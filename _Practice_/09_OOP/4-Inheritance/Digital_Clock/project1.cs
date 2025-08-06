
namespace OOP_Inheritance.Digital_Clock
{
   public class Clock{
        protected int Hour { get; set; }
        protected int Minutes { get; set; }

        public DateTime GetTime() => DateTime.Now;
    }

    public class AlarmClock : Clock{
        private readonly Validator _validator;
        
        public AlarmClock(Validator validator)
        {
            _validator = validator;
        }
        private DateTime _alarmTime { get; set; }

        public DateTime AlarmTime => _alarmTime;

        public void SetAlarm(){
            var getTime = GetTime();

            Console.WriteLine("Please set the alarm");
            Hour = _validator.IsIntegerValid("Hour: ");

            Minutes = _validator.IsIntegerValid("Minutes: ", "m");
              
            _alarmTime = getTime.Date.Add(new TimeSpan(Hour, Minutes, 0));            
            
            if(_alarmTime <= getTime){
                _alarmTime = _alarmTime.AddDays(1);
            }
        }
    }

    public class Validator {
        public int IsIntegerValid(string text, string unit = "h") {

            int returnValue = 0;
            while (true) {
                Console.Write(text);
                string? input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int value)) {
                    if (IsTimeValid(value, unit))
                    {
                        return value;
                    }                

                } else {
                    Console.WriteLine("Please enter valid entry.");
                }
            }
        }

        public bool IsTimeValid(int value, string unit = "h")
        {            
            if (value >= 0 && value < 24 && unit == "h")
            {
                return true;
            } else if (value >= 0 && value <= 59 && unit == "m")
            {
                return true;
            }else{
                Console.WriteLine("Entered time is not valid.");
                return false;
            }            
        }
    }
}
