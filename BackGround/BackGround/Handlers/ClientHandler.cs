using Background.ExportFileModels;
using BackGround.ConstantsAndEnums;
using BackGround.Factories;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Ziekenhuis.Model;
using BackGround.Utilities;
using BackGround.ExportFileModels;
using BackGround.ExportFileModels.InterfacesForExport;
using System.ComponentModel;
using Background.ExportFileModels.ClientModels;

namespace BackGround.Handlers
{
    // Where T: Class kan ook, maar "where T: BaseClient, IGenericFields" dit is specifieker en beter ! 
    // Where T: Class moet je nooit gebruiken (best practice), want een 
    // andere programmeur kan deze T ook voor een ander soort klasse dan Client misbruiken. 
    internal static class ClientHandler<T> where T : BaseClient, IAuditFields   // T erft van BaseClient, en T implementeert IGenericFields
        // BaseClient bevat generieke klant-velden, IGenericFields bevat generieke velden, nuttig voor alle soorten entiteiten
    {
        internal static void CreateOutgoingClients(List<Client> listClient, TypeOfClient soortKlant,
            TypeOfExport typeOfExport, IConfiguration configuration)
        {
            List<T> listOutgClient;

            listOutgClient = ClientFactory.CreateListClients<T>(soortKlant, listClient);
            var soortUitgFile = soortKlant switch
            {
                TypeOfClient.Big => KindOutgoingFile.BigClient,
                TypeOfClient.Small => KindOutgoingFile.SmallClient,
                TypeOfClient.Criminal => KindOutgoingFile.CriminalClient,
                TypeOfClient.WithManyConsults => KindOutgoingFile.ManyConsultsClient,
                _ => throw new InvalidEnumArgumentException(),
            };
            PathsAndFolders.CreateFileNamesAndDirectories
                (soortUitgFile,
                typeOfExport,
                configuration,
                out string fileName,
                out string fullFileName);

            var klantExportFileModel = ClientFactory.CreateKlantExportFileModel(listOutgClient, fileName);
            klantExportFileModel.SerializeToClientFile<T>(fullFileName, typeOfExport);

        }

    }
}
