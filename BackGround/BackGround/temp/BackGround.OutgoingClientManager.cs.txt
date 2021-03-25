using Background.ExportFileModels;
using Background.ExportFileModels.ClientModels;
using Background.Interfaces;
using BackGround.ConstantsAndEnums;
using BackGround.Handlers;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using Ziekenhuis.DataAccess.Interfaces;

// Uitsturen van client-gegevens:

// Grote clienten   BigClient
// Kleine clienten  SmallClient
// Criminele clienten   CriminalClient

// In deze functie werken we met een method die een interface
// teruggeeft, en casten we met AS IS en (). 

namespace Background.Managers
{
    public class OutgoingClientManager : IOutgoingClientManager
    {
        private readonly IClientRepository _clientRepository;
        private readonly IConfiguration _configuration;


        public OutgoingClientManager(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            _configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
        }

        public void CreateOutgClientFile(TypeOfClient typeOfClient, TypeOfExport typeOfExport)
        {
            Console.WriteLine("Retrieving all Clients from database ---");
            // Dankzij include in repos hebben we per Client ook Country en Doctor (N: 1)
            // Dankzij include in repos hebben we per Client ook al zijn Consults (1:N)
            var listClient = _clientRepository.GetAllWithConsults(); 

            switch (typeOfClient)
            {
                case TypeOfClient.Big:
                    ClientHandler<BigClient>.CreateOutgoingClients(listClient, typeOfClient, typeOfExport, _configuration);
                    break;
                case TypeOfClient.Small:
                    ClientHandler<SmallClient>.CreateOutgoingClients(listClient, typeOfClient, typeOfExport, _configuration);
                    break;
                case TypeOfClient.Criminal:
                    ClientHandler<CriminalClient>.CreateOutgoingClients(listClient, typeOfClient, typeOfExport, _configuration);
                    break;
                case TypeOfClient.WithManyConsults:
                    ClientHandler<WithManyConsultsClient>.CreateOutgoingClients(listClient, typeOfClient, typeOfExport, _configuration);
                    break;
                default:
                    throw new InvalidEnumArgumentException(); 
            }

        }

    }
}
