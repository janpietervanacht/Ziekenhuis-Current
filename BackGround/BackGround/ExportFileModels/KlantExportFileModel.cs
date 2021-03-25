using System.Collections.Generic;

namespace BackGround.ExportFileModels
{
    public class KlantExportFileModel<T>
    {
        public Header HeaderRecord { get; set; }
        public List<T> KlantLijst { get; set; }
        public Footer FooterRecord { get; set; }
    }

}
