using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    public interface IDocument
    {
        void DisplayDocument();
    }
    public class Dcoument
    {
        public string Title { get; private set; }
        public string Content { get; private set; }

        private string _fileName;

        public Dcoument(string fileName)
        {
            _fileName = fileName;
            LoadDocument(fileName);
            Console.WriteLine("document created");
        }

        private void LoadDocument(string fileName)
        {
            Console.WriteLine("Executing expensive action: loading a file " + fileName + " from disk");


            Task.Delay(2000).Wait();

            Title = $" This is sample Tiltle of {_fileName}";
            Content = $" This is sample content of {_fileName}";

        }

        public void DisplayDocument()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("diplaying contents of ".ToUpper() + _fileName.ToUpper());
            Console.WriteLine($"Title: {Title},\nContent: {Content}".ToUpper());
            Console.WriteLine("=========================================");
        }
    }
}
