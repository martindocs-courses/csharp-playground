// we can remove those generated automatically as we have already generated globals in ..\obj\Debug\net8.0
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

/* 
    NAMESPACE - declare a scope that contains a set of related types
    * if we have more class used for reading and writing data, for example, from a database, and those classes could be added to the same namespace. They would still have their own files, but all those files would have the same namespace.   
    * it is a good practice namespaces matching the folder structure
    * we can have more than one namespace in the same file
    
    GLOBAL using - If you ever notice that in your project you import some namespace over and over again, consider importing it globally and it separate file.
*/
namespace _single_responsibility_principle.DataAccess
// removing the braces for namespace and and with semicolon will give exactly the same result as before. This feature is called file-scoped namespace declarations. C#10 and newer 
//  namespace _single_responsibility_principle.DataAccess;
{
    class StringTextualRepository
    {
        private static readonly string Separator = Environment.NewLine;

        public List<string> Read(string filePath)
        {
            var fileContents = File.ReadAllText(filePath);
            return fileContents.Split(Separator).ToList();
        }

        public void Write(string filePath, List<string> strings) =>
            File.WriteAllText(filePath, string.Join(Separator, strings));
    }
}
