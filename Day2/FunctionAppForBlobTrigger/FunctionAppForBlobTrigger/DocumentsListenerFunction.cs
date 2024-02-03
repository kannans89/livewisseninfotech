using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionAppForBlobTrigger
{
    public class DocumentsListenerFunction
    {
        private readonly ILogger<DocumentsListenerFunction> _logger;

        public DocumentsListenerFunction(ILogger<DocumentsListenerFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(DocumentsListenerFunction))]
        public async Task Run([BlobTrigger("documents/{name}", Connection = "day2store")] Stream stream, string name)
        {
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
        }
    }
}
