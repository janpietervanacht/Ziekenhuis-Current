using BackGround.ConstantsAndEnums;

namespace Background.Interfaces
{
    public interface IOutgoingInvoiceManager
    {
        void CreateOutgInvoiceFile(SoortUitgFactuur soortUitgFactuur, TypeOfExport typeOfExport); 
        
    }
}