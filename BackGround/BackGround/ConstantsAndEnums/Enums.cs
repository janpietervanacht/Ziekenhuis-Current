namespace BackGround.ConstantsAndEnums
{
    public enum SoortUitgFactuur   
    {
        Big,
        Small
    }

    public enum KindOutgoingFile
    {
        BigInvoice,
        SmallInvoice,
        BigClient,
        SmallClient,
        CriminalClient,
        ManyConsultsClient
    }


    public enum TypeOfClient
    {
        Big,
        Small,
        Criminal,
        WithManyConsults
    }

    public enum TypeOfExport
    {
       XML,
       JSON,
       CSV
    }

}
