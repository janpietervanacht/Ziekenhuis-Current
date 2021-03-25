using System.Collections.Generic;
using Ziekenhuis.Background.ImportFileModels;

namespace Ziekenhuis.BackGround.ImportFileModels
{
    public class PaymentImportFileModel
    {
        public Header HeaderRecord { get; set; }
        public List<IncomingPayment> PaymentList { get; set; }
        public Footer FooterRecord { get; set; }
    }

    public class Header
    {
        public string BICOfBank { get; set; }
        
        public string FileName { get; set; }
        public string DateTimeImported { get; set; } // geformatteerde timestamp string
    }

    public class Footer
    {
        public int NrofRecords { get; set;  }
    }
}
