namespace Ziekenhuis.ConstantsAndEnums
{
    public enum ActionCode  // voor een dropdownlist bij Wijzig Client
    {
        A,
        I
    }


    public enum DoctorTypeEnum
    // hiermee voorkom je magic strings
    {
        Oogarts, Longarts, KNOarts, Oorarts
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
