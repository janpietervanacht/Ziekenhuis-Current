using System;
using System.Collections.Generic;
using System.Text;


namespace BackGround.ExportFileModels.InterfacesForExport
{
    /// <summary>
    /// Deze interface verplicht het opnemen van velden, die gelden voor alles 
    /// wat wordt geëxporteerd. Dus niet binnen één boom (BaseInvoice en daaronder BigInvoice en SmallInvoice)
    /// maar een interface werkt over alle bomen heen (dus export van bijvoorbeeld een klantenbestand zal ook
    /// deze interface implementeren).
    /// De interface pas ik toe in de factory. 
    /// </summary>
    public interface IAuditFields
    {
        public string CompanyName { get; set; }
        public string CreatedBy { get; set; }
        public string DateTimeCreated { get; set; }
    }
}
