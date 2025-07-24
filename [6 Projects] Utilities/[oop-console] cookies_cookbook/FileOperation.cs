using System.Text.Json;

namespace cookies_cookbook
{
    // Abstract class that defines common functionality for file operations
    public abstract class FileOperation
    {      
        public abstract string FileFormat{ get; }

        // Available ingredients instance for displaying preparation steps later
        public readonly AvailableIngredients _ingredients;

        // Constructor initializes the ingredients
        public FileOperation(AvailableIngredients ingredients)
        {
            _ingredients = ingredients;
        }

        // Helper method to get the file path based on the format
        public string GetFilePath(){
            string FileName = "recipes";            
            return $"{FileName}.{FileFormat}";
        }

        // Abstract methods for reading from and saving to files
        public abstract void SaveToFile(List<string> ids);
        public abstract void ReadFromFile();
    }

    // Handling JSON file operations
    class JSONFileOperation : FileOperation
    {
        public JSONFileOperation(AvailableIngredients ingredients) : base(ingredients) {}

        public override string FileFormat => "json";

        // Method to read recipes from a JSON file
        public override void ReadFromFile()
        {
            string path = GetFilePath();

            if (File.Exists(path))
            {
                // Read all existing JSON content
                string existingContent = File.ReadAllText(path);

                // De-serialize into List<string>
                var convertExistingDataToObject = JsonSerializer.Deserialize<List<string>>(existingContent) ?? new List<string> { }; // If the expression on the left of null-coalescing operator ?? is null, the operator returns the value on the right. 

                // Print existing recipes
                Console.WriteLine("Existing recipes are: \n");     
                for (var i = 0; i < convertExistingDataToObject.Count; i++)
                {
                    Console.WriteLine($"***** {i+1} *****");
                    var ids = new List<string> { convertExistingDataToObject[i] };
                    _ingredients.IngredientPrep(ids);
                }

                Console.WriteLine();
            }
        }

        // Method to save recipe (IDs) to a JSON file
        public override void SaveToFile(List<string> ids)
        {
            var newData = new List<string>{};
            string path = GetFilePath();

            if(File.Exists(path)){

                // Read all existing JSON content
                string existingContent = File.ReadAllText(path);

                // De-serialize into List<string>
                var convertExistingDataToObject = JsonSerializer.Deserialize<List<string>>(existingContent) ?? new List<string>{}; // If the expression on the left of null-coalescing operator ?? is null, the operator returns the value on the right. 

                // Add new data to the list
                convertExistingDataToObject.AddRange(ids);

                string updatedData = JsonSerializer.Serialize(convertExistingDataToObject);

                // Takes a single string (entire text) and writes a single string to a file, replacing any existing content in the file.
                File.WriteAllText(path, updatedData);            

            }else{
                // If the file doesn't exist, create a new file and add the new recipe
                newData.Add(JsonSerializer.Serialize(ids));
                // Takes an IEnumerable<string> and writes multiple lines to a file, where each element in the collection (e.g., an array or a list of strings) represents a line in the file.
                File.WriteAllLines(path, newData);            
            }
        }
    }

    // TXT file operations
    class TXTFileOperation : FileOperation
    {
        public TXTFileOperation(AvailableIngredients availableIngredients) : base(availableIngredients){}

        public override string FileFormat => "txt";

        // Read recipes from a TXT file
        public override void ReadFromFile()
        {
            string path = GetFilePath();

            if(File.Exists(path)){

                Console.WriteLine("Existing recipes are: \n");
                int i = 1;
                foreach (var line in File.ReadLines(path))
                {
                    Console.WriteLine($"***** {i} *****");
                    var ids = new List<string> { line };
                    _ingredients.IngredientPrep(ids);
                    i++;
                }
                Console.WriteLine();
            }
        }

        // Save a new recipe (IDs) to a TXT file
        public override void SaveToFile(List<string> ids)
        {
            var newData = new List<string>{};
            string path = GetFilePath();

            if (File.Exists(path)){

                // Read all existing TXT content
                var existingContent = File.ReadLines(path);

                // Add all existing data to an array
                newData.AddRange(existingContent);

                // Append new data to existing data on the separate line
                newData.Add(string.Join(",", ids)); 
                
                // Write to TXT file
                File.WriteAllLines(path, newData); 

            }else{
                // If the file doesn't exist, create a new file and add the new recipe
                newData.Add(string.Join(",", ids));
                File.WriteAllLines(path, newData);            
            }
        }
    }
}
