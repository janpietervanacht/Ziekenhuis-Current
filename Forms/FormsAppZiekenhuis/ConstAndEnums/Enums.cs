namespace FormsAppZiekenhuis.ConstantsAndEnums
{
    public enum FieldName   
    {
        ClientNumber,
        FirstName,
        LastName,
        IsInsured,
        Zodiac

    }; 

    public enum Severity  // voor een dropdownlist bij Wijzig Client
    {
        Info,
        Warning,
        Error
    }

    public enum AstrologyZodiacSign  
    {
        Steenbok, Waterman, Vissen,
        Ram, Stier, Tweeling,
        Kreeft, Leeuw, Maagd,
        Weegschaal, Schorpioen, Boogschutter
    }

    public enum SportType
    {
        // Geen sporter, team sporter etc
        Geen, Team, Individueel, Denk
    }
}
