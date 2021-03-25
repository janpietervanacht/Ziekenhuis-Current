using FormsAppZiekenhuis.ConstantsAndEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FormsAppZiekenhuis.FieldChecks
{
    public static class Check
    {
        public static ErrMsg CheckField(
                FieldName fieldName, string fieldContent) // Optioneel veld
        {
            ErrMsg errMsg = null; 

            switch (fieldName)
            {
                case FieldName.FirstName:
                    errMsg = CheckNormalString(fieldContent);
                    break;
                case FieldName.LastName:
                    errMsg = CheckNormalString(fieldContent);
                    break;
                case FieldName.IsInsured:
                    errMsg = CheckListOfStrings(fieldContent, "J", "N"); // params
                    break;
                case FieldName.Zodiac:
                    // Controleer of het sterrenbeeld in de enum-lijst zit: 
                    errMsg = CheckEnumValues<AstrologyZodiacSign>(fieldContent); // params
                    break;

                //case FieldName.Zodiac:
                //    errMsg = CheckZodiac(fieldContent); // params
                //    break;
                default:
                    break;
            }

            return errMsg; 
        }


        private static ErrMsg CheckEnumValues<T>(string fieldContent) where T: Enum 
        {
            var errMsg = new ErrMsg();

            var match = Enum.IsDefined(typeof(T), fieldContent.Trim());
            if (match)
            {
                errMsg.ErrorId = "00";
            }
            else
            {
                errMsg.ErrorId = "03";
                errMsg.ErrorMessage = $"String \"{fieldContent}\" niet in toegestane lijst";

            }
            
            return errMsg;

        }

        //private static ErrMsg CheckZodiac(string fieldContent)
        //{
        //    var errMsg = new ErrMsg();

        //    var match = Enum.IsDefined(typeof(AstrologyZodiacSign), fieldContent.Trim());
        //    if (match)
        //    {
        //        errMsg.ErrorId = "00";
        //    }
        //    else
        //    {
        //        errMsg.ErrorId = "03";
        //        errMsg.ErrorMessage = $"String \"{fieldContent}\"is geen geldig sterrenbeeld:";
        //    }

        //    return errMsg; 

        //}

        private static ErrMsg CheckListOfStrings(string fieldContent, params string[] parmList)
        {
            var errMsg = new ErrMsg();  

            if (parmList.Contains(fieldContent))
            {
                errMsg.ErrorId = "00";
            }
            else
            {
                errMsg.ErrorId = "01";
                errMsg.ErrorMessage = $"String \"{fieldContent}\"is not in the following list:";
                foreach (var item in parmList)
                {
                    errMsg.ErrorMessage += " " + item.ToString();
                }
            }

            return errMsg; 
        }

        private static ErrMsg CheckNormalString(string fieldContent)
        {
            var pattern = "^[A-Z][A-Za-z0-9-_ ]{0,100}$";
            Regex regex = new Regex(pattern);
            bool match = regex.IsMatch(fieldContent);

            var errMsg = new ErrMsg();

            if (match)
            {
                errMsg.ErrorId = "00";
            }
            else
            {
                errMsg.ErrorId = "02";
                errMsg.ErrorMessage = "Naam begint met hoofdletter en bevat alleen letters, cijfers, spaties, strepen en underscores";
            }

            return errMsg; 
        }
       
    }
}
