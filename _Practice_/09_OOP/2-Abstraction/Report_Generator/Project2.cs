
namespace OOP_Abstraction.Report_Generator
{
    public class Report{

        public void Generate(){
            FetchData();
            ProcessData();
            FormatData();
            ExportData();
        }

        private void FetchData(){
            Console.WriteLine("Fetch data...");
        }

        private void ProcessData(){
            Console.WriteLine("Process data.");
        }

        private void FormatData(){
            Console.WriteLine("Format data.");
        }

        private void ExportData(){
            Console.WriteLine("Export data.");
        }
    
    }
}
