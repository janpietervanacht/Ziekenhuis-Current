using BackGround.ExportFileModels.InterfacesForExport;

namespace Background.ExportFileModels.ClientModels
{

    // Best practice: exporteer nooit het Client model of andere classes uit project 'Model'
    // Niet doen bij WebApi's en ook niet doen als je een xml of json file op een schijf gaat aanmaken.

    // Want Client is voor intern gebruik, en kan wijzigen
    // Je wil niet dat de buitenwereld ineens een grotere Client krijgt

    // Tweede reden om het niet te doen: JSON kan een object cycle krijgen, omdat Intellisense
    // clienten en invoices en landen met elkaar koppelt.

    public class BigClient: BaseClient 
    {
        // Velden specifiek voor grote klant: 
        public string OmschrijvingGroteKlant 
        {
            get
            { return "Dit is een GROTE klant"; } 
        } 

    }
}
