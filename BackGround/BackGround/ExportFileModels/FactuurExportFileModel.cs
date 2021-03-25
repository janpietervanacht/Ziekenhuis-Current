using System.Collections.Generic;

namespace BackGround.ExportFileModels
{
    public class FactuurExportFileModel<T>
    {
        public Header HeaderRecord { get; set; }
        public List<T> FactuurLijst { get; set; }
        public Footer FooterRecord { get; set; }
    }
    
}
