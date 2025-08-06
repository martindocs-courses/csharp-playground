
namespace OOP_Composition.Stopwatch_TimeTracker
{
   
    public class TimeTracker{
        public DateTime CurrentTime() => DateTime.Now;
    }

    public class StopWatch{
        private readonly TimeTracker _tracker;

        public StopWatch(TimeTracker tracker)
        {
            _tracker = tracker;
        }

        public void TimingInfo() => Console.WriteLine(_tracker.CurrentTime());
    }
}
