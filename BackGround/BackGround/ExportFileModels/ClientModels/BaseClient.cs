using BackGround.ExportFileModels.InterfacesForExport;

namespace Background.ExportFileModels.ClientModels
{
    public abstract class BaseClient: IAuditFields // is een abstract class, want we willen geen instantie ervan
    {
        // Best practice: exporteer nooit het Client model of andere classes uit project 'Model'
        // Niet doen bij WebApi's en ook niet doen als je een xml of json file op een schijf gaat aanmaken.

        // Want Client is voor intern gebruik, en kan wijzigen
        // Je wil niet dat de buitenwereld ineens een grotere Client krijgt

        // Tweede reden om het niet te doen: JSON kan een object cycle krijgen, omdat Intellisense
        // clienten en invoices en landen met elkaar koppelt.

        public int KlantNummer { get; set; }  // Het functionele client-nummer
        public string VolledigeNaamKlant { get; set; }
        public string WoonPlaats { get; set; }

        // Velden uit interface: 
        public string CompanyName { get; set; }
        public string CreatedBy { get; set; }
        public string DateTimeCreated { get; set; }

    }
}
