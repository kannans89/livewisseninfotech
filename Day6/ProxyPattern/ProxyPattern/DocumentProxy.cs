using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    internal class DocumentProxy : IDocument
    {

        private Dcoument _document;
        private string _fileName;

        public DocumentProxy(string fileName)
        {
            _fileName = fileName;

            // complete code here ...

        }

        public void DisplayDocument()
        {

            if (_document == null)
            {
                _document = new Dcoument(_fileName);
            }
            _document.DisplayDocument();
        }
    }
   
}
