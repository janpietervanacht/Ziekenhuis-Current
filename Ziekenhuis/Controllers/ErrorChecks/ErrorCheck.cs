using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Ziekenhuis.Model;
using Ziekenhuis.Model.ConstantsAndEnums;
using Ziekenhuis.Ziekenhuis.ViewModels;

// Deze class bevat extension methods om de default
// velden van de ModelView te vullen. 

namespace Ziekenhuis.Ziekenhuis.Controllers.ErrorChecks
{
    public static partial class ErrorCheck
    // In een static class zijn alle properties/methods ook static
    {
        const string patternGeneral = "^[A-Za-z0-9-_ ]{0,50}$";
        const string patternAmount = "^[0-9][0-9]{0,}[,][0-9]{2}$";
        // Onderstaande: eerste karakter moet hoofdletter zijn
        // const string patternGeneral = "^[A-Z][A-Za-z0-9-_ ]{0,49}$";

        // ------------------------------------------------------------------------- 
        internal static string CheckForErrors(ClientViewModel cltVM)
        {

            bool fmtOK;

            fmtOK = CheckFmt(cltVM.Client.FirstName, patternGeneral);
            if (!fmtOK)
            {
                return "Formaat van \'Voornaam\' is incorrect";
            }

            fmtOK = CheckFmt(cltVM.Client.LastName, patternGeneral);
            if (!fmtOK)
            {
                return "Formaat van \'Achternaam\' is incorrect";
            }

            fmtOK = CheckFmt(cltVM.Client.Street, patternGeneral);
            if (!fmtOK)
            {
                return "Formaat van \'Straat\' is incorrect";
            }

            const string patternPostCode = "^[1-9][0-9]{3}[A-Z]{2}$";

            fmtOK = CheckFmt(cltVM.Client.PostalCode, patternPostCode);
            if (!fmtOK)
            {
                return "Formaat van \'Postcode\' is incorrect";
            }


            fmtOK = CheckFmt(cltVM.Client.City, patternGeneral);
            if (!fmtOK)
            {
                return "Formaat van \'Woonplaats\' is incorrect";
            }

            //fmtOK = CheckFmt(cltVM.Client.Country, patternGeneral);
            //if (!fmtOK)
            //{
            //    return "Formaat van \'Land\' is incorrect";
            //}

            // Controleer of de client niet te oud is
            if (cltVM.Client.BirthDate < Const.cMinBirthDate)
            {
                var maxBdate = Const.cMinBirthDate.ToString("dd/MM/yyyy");

                return $"Client {cltVM.ClientFullName} mag " +
                    $"niet eerder zijn geboren " +
                    $"dan op {maxBdate}";
            }

            // Controleer dat de client niet in de toekomst is geboren
            if (cltVM.Client.BirthDate > DateTime.Today)
            {
                return $"Client {cltVM.ClientFullName} kan niet in de toekomst geboren zijn";
            }

            // Controleer dat het aanwezig budget groter is dan het minimum 
            if (cltVM.Client.BudgetAvaiable < Const.cMinBudget)
            {
                return $"Budget moet minimaal gelijk zijn aan {Const.cMinBudget}";
            }

            // Controleer dat het aanwezig budget kleiner is dan het maximum 
            if (cltVM.Client.BudgetAvaiable > Const.cMaxBudget)
            {
                return $"Budget moet maximaal gelijk zijn aan {Const.cMaxBudget}";
            }

            return null;
        }

        private static bool CheckFmt(string text, string pattern)
        {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(text);
        }

        // ----------------------------------------------------------------------- 
        internal static string CheckForErrors(PrescrWith5LinesViewModel pW5LinesVM)
        {
            bool fmtOK;

            fmtOK = CheckFmt(pW5LinesVM.Prescription.PrescriptionDescr, patternGeneral);
            if (!fmtOK)
            {
                return "Formaat van \'Omschrijving recept\' is incorrect";
            }

            if (pW5LinesVM.Line1 != null)
            {
                fmtOK = CheckFmt(pW5LinesVM.Line1, patternGeneral);
                if (!fmtOK)
                {
                    return "Formaat van \'Recept regel 1\' is incorrect";
                }
            }

            if (pW5LinesVM.Line2 != null)
            {
                fmtOK = CheckFmt(pW5LinesVM.Line2, patternGeneral);
                if (!fmtOK)
                {
                    return "Formaat van \'Recept regel 2\' is incorrect";
                }
            }

            if (pW5LinesVM.Line3 != null)
            {
                fmtOK = CheckFmt(pW5LinesVM.Line3, patternGeneral);
                if (!fmtOK)
                {
                    return "Formaat van \'Recept regel 3\' is incorrect";
                }
            }

            if (pW5LinesVM.Line4 != null)
            {
                fmtOK = CheckFmt(pW5LinesVM.Line4, patternGeneral);
                if (!fmtOK)
                {
                    return "Formaat van \'Recept regel 4\' is incorrect";
                }
            }

            if (pW5LinesVM.Line5 != null)
            {
                fmtOK = CheckFmt(pW5LinesVM.Line5, patternGeneral);
                if (!fmtOK)
                {
                    return "Formaat van \'Recept regel 5\' is incorrect";
                }
            }

            return null;
        }

        internal static string CheckForErrors(ConsultViewModel consVM)
        {

            bool fmtOK;

            fmtOK = CheckFmt(consVM.Consult.ConsultDescr, patternGeneral);
            if (!fmtOK)
            {
                return "Formaat \'Consult Omschrijving\' is incorrect";
            }


            // Controleer dat de datum niet in de toekomst is  
            if (consVM.Consult.ConsultDate > DateTime.Today)
            {
                return $"Datum consult is nu: \' {consVM.Consult.ConsultDate} \'- kan niet in de toekomst zijn";
            }

            return null;
        }

        internal static string CheckForErrors(InvoiceViewModel invVM)
        {
            bool fmtOK;
            fmtOK = CheckFmt(invVM.Invoice.InvoiceDescription, patternGeneral);
            if (!fmtOK)
            {
                return "Formaat van \'Omschrijving factuur\' is incorrect";
            }

            var tmpString = invVM.Invoice.Amount.ToString();
            fmtOK = CheckFmt(tmpString, patternAmount);
            if (!fmtOK)
            {
                return "Factuurbedrag heeft incorrect formaat, gebruik altijd de komma en 2 decimalen";
            }


            if (invVM.Invoice.Amount <= 0)
            {
                return "Bedrag van de factuur moet positief zijn";
            }

            if (invVM.Line1 != null)
            {
                fmtOK = CheckFmt(invVM.Line1, patternGeneral);
                if (!fmtOK)
                {
                    return "Formaat van \'Factuur regel 1\' is incorrect";
                }
            }

            if (invVM.Line2 != null)
            {
                fmtOK = CheckFmt(invVM.Line2, patternGeneral);
                if (!fmtOK)
                {
                    return "Formaat van \'Factuur regel 2\' is incorrect";
                }
            }

            if (invVM.Line3 != null)
            {
                fmtOK = CheckFmt(invVM.Line3, patternGeneral);
                if (!fmtOK)
                {
                    return "Formaat van \'Factuur regel 3\' is incorrect";
                }
            }

            return null;

        }
    }
}
