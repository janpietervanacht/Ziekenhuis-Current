using Background.ExportFileModels;
using Background.ExportFileModels.ClientModels;
using BackGround.ConstantsAndEnums;
using BackGround.ExportFileModels;
using BackGround.ExportFileModels.InterfacesForExport;
using System;
using System.Collections.Generic;
using System.Linq;
using Ziekenhuis.Model;

namespace BackGround.Factories
{
    // We gebruiken geen Generics hier, omdat we willen oefenen
    // met casting (AS, IS) bij de export van 3 soorten clienten

    public static class ClientFactory
    {
        // Gebruik in een static class alleen static fields, static props en static methods
        public static int aantalKeerCreateListClients = 0;
        // public int MagNiet { get; set; } // compileert niet, want MagNiet is een instance member
        // public static int MagWel { get; set; } // compileert wel 

        public static List<T> CreateListClients<T>(TypeOfClient soortKlant, List<Client> listClient) where T : BaseClient, IAuditFields
            // T kan zijn: BigClient, SmallClient, CriminalClient
        {
            // Correct is ook: 
            // var result = new List<BigClient>();
            //foreach (var clt in listClient)
            //{
            //    var clientExport = MaakNieuweClient(clt, SoortKlant.Big) as BigClient;
            //    result.Add(clientExport);
            //}

            // Let op de casting van de Interface IgenericFields naar T: (XXX)

            aantalKeerCreateListClients++;
            var result = listClient.Select(c => MaakNieuweClient(c, soortKlant) as T).ToList();
            return result;
        }

        public static IAuditFields MaakNieuweClient(Client clt, TypeOfClient soortKlant)
        // Deze method retourneert een BigClient, SmallClient, CriminalClient of WithManyConsultsClient
        // Echter in design time retourneert deze functie een object die voldoet aan IGenericFields
        // Runtime kan je na aanroep van deze functie casten naar type T (XXX)
        {
            switch (soortKlant)
            {
                case TypeOfClient.Big:
                    var result1 = new BigClient
                    {
                        // Velden uit GenericFields: 
                        CompanyName = "JP-BV voor GROTE klanten",
                        CreatedBy = "USERJP",
                        DateTimeCreated = DateTime.Now.ToString(),

                        // Velden uit BaseClient: 
                        KlantNummer = clt.ClientNumber,
                        VolledigeNaamKlant = clt.FirstName + " " + clt.LastName,
                        WoonPlaats = clt.City,

                        // Eigen veld: 
                        // OmschrijvingGroteKlant = "Dit is een GROTE klant" dit is geregeld in de property GET
                    };
                    return result1;

                case TypeOfClient.Small:
                    var result2 = new SmallClient
                    {
                        // Velden uit GenericFields: 
                        CompanyName = "JP-BV voor KLEINE klanten",
                        CreatedBy = "USERJP",
                        DateTimeCreated = DateTime.Now.ToString(),

                        // Velden uit BaseClient: 
                        KlantNummer = clt.ClientNumber,
                        VolledigeNaamKlant = clt.FirstName + " " + clt.LastName,
                        WoonPlaats = clt.City,

                        // Eigen veld: 
                        OmschrijvingKleineKlant = "Dit is een KLEINE KLANT"
                    };
                    return result2;

                case TypeOfClient.Criminal:
                    var result3 = new CriminalClient
                    {
                        // Velden uit GenericFields: 
                        CompanyName = "JP-BV voor CRIMINELE klanten",
                        CreatedBy = "USERJP",
                        DateTimeCreated = DateTime.Now.ToString(),

                        // Velden uit BaseClient: 
                        KlantNummer = clt.ClientNumber,
                        VolledigeNaamKlant = clt.FirstName + " " + clt.LastName,
                        WoonPlaats = clt.City,

                        // Eigen veld:
                        OmschrijvingCrimineleKlant = "Dit is een CRIMINELE KLANT"
                    };
                    return result3;

                case TypeOfClient.WithManyConsults:

                    // Stel een klant heeft geen consulten: 
                    // Dankzij de null propagation hieronder kan listOfConsults NULL zijn
                    // en krijg je geen knaller bij .Select (want .Select verwacht altijd minimaal één element). 
                    var listConsults = clt.ListOfConsults?  
                       .Select(c => new Consultatie  // Via deze truc maak je een nieuwe lijst met nieuwe kolommen
                       {
                           ConsultDatum = c.ConsultDate,
                           ConsultOmschrijving = c.ConsultDescr,
                           PrijsVanConsult = c.Price
                       }
                       ).ToList();

                    var result4 = new WithManyConsultsClient
                    {
                        // Velden uit GenericFields: 
                        CompanyName = "JP-BV voor MET-VELE-CONSULTEN klanten",
                        CreatedBy = "USERJP",
                        DateTimeCreated = DateTime.Now.ToString(),

                        // Velden uit BaseClient: 
                        KlantNummer = clt.ClientNumber,
                        VolledigeNaamKlant = clt.FirstName + " " + clt.LastName,
                        WoonPlaats = clt.City,

                        // Eigen veld:
                        OmschrijvingKlantMetVeleConsulten = "Dit is een VELE-CONSULTEN KLANT",

                        ListConsults = listConsults 

                    };
                    return result4;

                default:
                    throw new Exception();

            }

        }

        public static KlantExportFileModel<T> CreateKlantExportFileModel<T>(List<T> listOutgClient, string fileName)
        {
            return new KlantExportFileModel<T>()
            {
                HeaderRecord = new Header()
                {
                    FileName = fileName,
                    DateTimeExported = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
                },
                KlantLijst = listOutgClient, // generic
                FooterRecord = new Footer()
                {
                    NrofRecords = listOutgClient.Count()
                }
            };
        }

    }

}
