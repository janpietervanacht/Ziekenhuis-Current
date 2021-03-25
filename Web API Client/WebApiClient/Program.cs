using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using WebApiClient.ConstantsAndEnums;
using WebApiClient.RetrieveFunctions;
using WebApiClient.UpdateFunctions;

namespace Ziekenhuis.WebApiClient
{
    // Opmerking: dit is een 100 procent onafhankelijk project van de 
    // andere projecten in de Solution Ziekenhuis. 
    public class Program
    {
        static async Task Main(string[] args)
        {
            await Retrieval.GetAlleClienten(); 
            await Retrieval.Get1Client();

            var builder = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettingsJP.json", optional: true, reloadOnChange: true);

            var expFolder = builder.Build().GetSection("AppSettings").GetSection("ExportFolderFromClientApp").Value;
            var expFilePut = builder.Build().GetSection("AppSettings").GetSection("ExportFilePut").Value;
            var expFilePost = builder.Build().GetSection("AppSettings").GetSection("ExportFilePost").Value;


            await PostPutDel.PutOrPost1Client(Mode.Post, expFolder, expFilePost);
            await PostPutDel.PutOrPost1Client(Mode.Put, expFolder, expFilePut);
            await PostPutDel.Delete1Client(); 
            //----------------------------------------------------------
            Console.Write("\nEinde Client Applic, druk op toets"); 
            Console.ReadKey(); 
        }

    }
}
