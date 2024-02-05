using Azure.Identity;
using Azure.Storage.Blobs;


string tenantId = "f0093ae3-bfa4-46e1-9b91-668278209d56";
string clientId = "01c8152f-74d4-4e46-b1bd-83443abc22fd";
string clientSecret = "z_f8Q~yE71UnLnGaRRouZ6LKbRsP5ys5bNcNYcIC";


string blobURI = "https://day4storewissen.blob.core.windows.net/images/bahnmi.jpg";
string filePath = "C:\\temp\\newimg.jpg";

ClientSecretCredential clientCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);

BlobClient blobClient = new BlobClient(new Uri(blobURI), clientCredential);

await blobClient.DownloadToAsync(filePath);

Console.WriteLine("The blob is downloaded");

