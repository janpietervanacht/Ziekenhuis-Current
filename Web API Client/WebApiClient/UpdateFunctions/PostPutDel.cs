using System;
using System.IO;
using System.Net.Http;
using System.Text;
// using System.Text.Json;  HEB IK VERVANGEN DOOR NEWTONSOFT.JSON
using System.Threading.Tasks;
using WebApiClient.ConstantsAndEnums;

namespace WebApiClient.UpdateFunctions
{
    public static class PostPutDel
    {

        private static readonly HttpClient client = new HttpClient();

        internal static async Task PutOrPost1Client(Mode mode, string expFolder, string expFile)  // Put or Get
        {

            var fullFileName = Path.Combine(expFolder, expFile);

        BEGIN:

            
            if (mode == Mode.Put)
            {
                Console.WriteLine("\nWe gaan nu een client PUTTEN (wijzigen)");
            }
            else
            {
                Console.WriteLine("\nWe gaan nu een client POSTEN (toevoegen)");
            }

            Console.WriteLine($"Is de file {fullFileName} aangepast en gesaved? \nDruk dan op een toets");
            Console.ReadKey();

            string fileString, jsonString = "";
            using (var file = new StreamReader(fullFileName))  
            {
                fileString = file.ReadToEnd();
            }

            string clientNumberAlfa = "";
            string Url;

            if (mode == Mode.Put)  // CHANGE
            {
                // Bij WIJZIGEN: 
                // De fileString is niet JSON compliant
                // Zoek het clientNummer op in de 1e regel, want het clientnummer moet
                // ook in de URL worden gezet
                // Verwijder daarna de eerste regel, zodat de string wèl JSON compliant wordt. 

                clientNumberAlfa = fileString.Substring(0, 6);
                int count = fileString.IndexOf("{");
                jsonString = fileString.Remove(0, count);
                Url = "https://localhost:5001/api/v1/clientapi" + $"/{clientNumberAlfa}";
                Console.WriteLine($"\n -- Sending the following client for UPDATE: ---- " +
                                  $"\n{jsonString}\n");
            }
            else // POST
            {
                // Bij toevoegen is de fileString WEL json compliant
                jsonString = fileString;
                Url = "https://localhost:5001/api/v1/clientapi";
                Console.WriteLine($"\n -- Sending the following client for ADD: ---- " +
                     $"\n{jsonString}\n");
            }

            HttpContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage httpRespMsg;

            if (mode == Mode.Put)  // CHANGE
            {
                httpRespMsg = await client.PutAsync(Url, httpContent);
            }
            else // POST = ADD
            {
                httpRespMsg = await client.PostAsync(Url, httpContent);
            }

            Console.WriteLine($"\n -- Receiving the following response: ---- \n");
            Console.WriteLine(httpRespMsg);

            if (mode == Mode.Put)  // CHANGE
            {
                Console.Write("\nDruk op ENTER voor doorgaan, andere toets voor opnieuw PUT");

            }
            else // POST = ADD
            {
                Console.Write("\nDruk op ENTER voor doorgaan, andere toets voor opnieuw POST");
            }

            var input = Console.ReadKey().Key;
            Console.WriteLine();
            if (input != ConsoleKey.Enter)
            {
                goto BEGIN;
            }
        }

        //------------------------------------------------------------------- 

        public static async Task Delete1Client()
        {
        BEGIN:

            Console.WriteLine($"\nWe gaan nu 1 client verwijderen.");
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


            //-------------------------------------------------------------- 

            try
            {
                var Url = "https://localhost:5001/api/v1/clientAPi/" + clientNumber;
                var stringTask = await client.DeleteAsync(Url);
            }
            catch (Exception errMsg)
            {
                Console.WriteLine($"\n--- Verwijderen {clientNumber} mislukt");
                Console.WriteLine(errMsg);
                goto BEGIN;
            }


            Console.Write("\nDruk op ENTER voor doorgaan\n" +
               "Andere toets voor opnieuw verwijderen individuele client\n");
            var input = Console.ReadKey().Key;
            Console.WriteLine();
            if (input != ConsoleKey.Enter)
            {
                goto BEGIN;
            }

        }
    }


}
