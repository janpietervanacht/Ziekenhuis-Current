using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
// using System.Text.Json;  HEB IK VERVANGEN DOOR NEWTONSOFT.JSON
using System.Threading.Tasks;
using Ziekenhuis.WebApiClient.DTOModels;

namespace WebApiClient.RetrieveFunctions
{
    public static class Retrieval
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task GetAlleClienten()
        {
            Console.WriteLine($"\nWe gaan nu alle clienten ophalen.");
            Console.WriteLine($"Druk op ENTER\n");
            Console.ReadKey();


            var stringTask = client.GetStringAsync("https://localhost:5001/api/v1/Clientapi");

            var jsonString = await stringTask;

            // var clientDTOList = JsonSerializer.Deserialize<List<ClientDTO>>(jsonString);
            var clientDTOList = JsonConvert.DeserializeObject<List<ClientRecordInc>>(jsonString);

            clientDTOList = clientDTOList.OrderBy(c => c.FirstName).ToList();

            for (int i = 0; i < clientDTOList.Count; i++)
            {
                Console.WriteLine($"Clientnummer: {clientDTOList[i].ClientNumber}");
                Console.WriteLine($"Voornaam    : {clientDTOList[i].FirstName}");
                Console.WriteLine($"Achternaam  : {clientDTOList[i].LastName}");
                Console.WriteLine($"Straat      : {clientDTOList[i].Street}");
                Console.WriteLine($"Huisnummer  : {clientDTOList[i].HouseNumber}");
                Console.WriteLine($"Plaats      : {clientDTOList[i].City}");
                Console.WriteLine($"Land        : {clientDTOList[i].CountryDescription}");


                Console.WriteLine($"Aantal fact : {clientDTOList[i].NrOfActiveInvoices}");

                Console.WriteLine("\n\n-------------------------\n\n");
            }

        }

        // ----------------------------------------------------------------------------------- 

        public static async Task Get1Client()
        {

        BEGIN:

            Console.WriteLine($"\nWe gaan nu 1 client ophalen.");
            Console.WriteLine($"Druk op ENTER");
            Console.ReadKey();

            Console.WriteLine("Geef het klantnummer op: ");
            var success = int.TryParse(Console.ReadLine(), out int clientNumber);
            if (!success)
            {
                Console.WriteLine("Geen correcte input");
                goto BEGIN;
            }
            if (clientNumber < 100000 || clientNumber >= 999999)
            {
                Console.WriteLine("Clientnummer moet tussen 100000 en 999999 liggen");
                goto BEGIN;
            }

            //------------------------------------------------------ 

            string jsonString;
            try
            {
                var Url = "https://localhost:5001/api/v1/clientAPi/" + clientNumber;
                var stringTask = client.GetStringAsync(Url);
                jsonString = await stringTask;
            }
            catch (Exception errMsg)
            {
                Console.WriteLine($"\n--- OPHALEN CLIENT {clientNumber} MISLUKT");
                Console.WriteLine(errMsg);
                goto BEGIN;
            }

            //------------------------------------------------------ 

            // var clientDTOList = JsonSerializer.Deserialize<List<ClientDTO>>(jsonString);
            var clientIncDTO = JsonConvert.DeserializeObject<ClientRecordInc>(jsonString);

            Console.WriteLine($"Clientnummer: {clientIncDTO.ClientNumber}");
            Console.WriteLine($"Voornaam    : {clientIncDTO.FirstName}");
            Console.WriteLine($"Achternaam  : {clientIncDTO.LastName}");
            Console.WriteLine($"Straat      : {clientIncDTO.Street}");
            Console.WriteLine($"Huisnummer  : {clientIncDTO.HouseNumber}");
            Console.WriteLine($"Plaats      : {clientIncDTO.City}");
            Console.WriteLine($"Land        : {clientIncDTO.CountryDescription}");


            Console.WriteLine($"Aantal fact : {clientIncDTO.NrOfActiveInvoices}");

            Console.Write("\nDruk op ENTER voor doorgaan naar \"PUT CLIENT\", \n" +
                "Andere toets voor ophalen nieuwe individuele client\n");
            var input = Console.ReadKey().Key;
            Console.WriteLine();
            if (input != ConsoleKey.Enter)
            {
                goto BEGIN;
            }

        }
    }


}
