using BackGround.ConstantsAndEnums;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.IO;

namespace BackGround.Utilities
{
    public static class PathsAndFolders 
    {
        /// <summary>
        /// Maak files en directories
        /// </summary>
        /// <param name="soortUitgFactuur"></param>
        /// <param name="configuration"></param>
        /// <param name="fileName"></param>
        /// <param name="fullFileName"></param>
        public static void CreateFileNamesAndDirectories
            (KindOutgoingFile soortUitgFile, 
            TypeOfExport typeOfExport,
            IConfiguration configuration, 
            out string fileName, 
            out string fullFileName) 
        {

            // Haal settings uit appsettings.json, de opvolger van web.config

            var mainFolderExport = configuration.GetSection("AppSettings")["MainFolderExport"];

            string fileNamePrefix;
            string subFolderExport;

            switch (soortUitgFile)
            {
                case KindOutgoingFile.BigInvoice:
                    subFolderExport = configuration.GetSection("AppSettings")["SubFolderInvoices"];
                    fileNamePrefix = configuration.GetSection("AppSettings")["PrefixBigInvoiceFile"];
                    break;
                case KindOutgoingFile.SmallInvoice:
                    subFolderExport = configuration.GetSection("AppSettings")["SubFolderInvoices"];
                    fileNamePrefix = configuration.GetSection("AppSettings")["PrefixSmallInvoiceFile"];
                    break;
                case KindOutgoingFile.BigClient:
                    subFolderExport = configuration.GetSection("AppSettings")["SubFolderClients"];
                    fileNamePrefix = configuration.GetSection("AppSettings")["PrefixBigClientFile"];
                    break;
                case KindOutgoingFile.SmallClient:
                    subFolderExport = configuration.GetSection("AppSettings")["SubFolderClients"];
                    fileNamePrefix = configuration.GetSection("AppSettings")["PrefixSmallClientFile"];
                    break;
                case KindOutgoingFile.CriminalClient:
                    subFolderExport = configuration.GetSection("AppSettings")["SubFolderClients"];
                    fileNamePrefix = configuration.GetSection("AppSettings")["PrefixCriminalClientFile"];
                    break;
                case KindOutgoingFile.ManyConsultsClient:
                    subFolderExport = configuration.GetSection("AppSettings")["SubFolderClients"];
                    fileNamePrefix = configuration.GetSection("AppSettings")["PrefixManyConsultsClientFile"];
                    break;
                default:
                    throw new Exception();
            }

            string extension; 
            switch (typeOfExport)   
            {
                case TypeOfExport.XML:
                    extension = ".xml"; 
                    break;
                case TypeOfExport.JSON:
                    extension = ".json";
                    break;
                case TypeOfExport.CSV:
                    extension = ".csv";
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }

            fileName = fileNamePrefix + " " + DateTime.Now.ToString("yyyyMMdd-HHmmss") + extension;  // (XXX)

            // Combine zorgt ervoor dat er geen verwarring ontstaat
            // bij het verbinden van folder-paden (soms zijn er wel of geen extra slashes aanwezig)

            var pathString = Path.Combine(mainFolderExport, subFolderExport);
            fullFileName = Path.Combine(pathString, fileName);
            if (!Directory.Exists(pathString))
            {
                Directory.CreateDirectory(pathString);
                Console.WriteLine($"Dir \"{pathString}\" created");
            }
            else
            {
                Console.WriteLine($"Directory \"{pathString}\" already exists");
            }
        }

    }
}
