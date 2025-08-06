
using System.Threading.Channels;

namespace OOP_Polymorphism.Document_Renderer
{
   public class Document{
        public virtual void Render() => Console.WriteLine("Rendering Document.");
   }

    public class PDFDocument : Document
    {
        public override void Render() => Console.WriteLine("Rendering PDF.");
    }

    public class WordDocument : Document
    {
        public override void Render() => Console.WriteLine("Rendering Word Doc.");
    }

    public class DocumentRender{
        List<Document> _documents = new List<Document>()
        {
            new Document(),
            new PDFDocument(),
            new WordDocument(),
        };
        
        public void Render(){
            foreach (var document in _documents)
            {
                document.Render();
            }
        }
    }
}
