using System;
using System.Collections.Generic;
using System.Linq;
using Ziekenhuis.Model;
using Ziekenhuis.Ziekenhuis.ViewModels;

// Deze class bevat extension methods om de default
// velden van de ModelView te vullen. 

namespace Ziekenhuis.Ziekenhuis.Controllers.MappingExtensions
{
    public static partial class MappingExtension
        // In een static class zijn alle properties/methods ook static
    {
        //------------------------------------------------------------------- 

        internal static Prescription ToPrescr(this PrescrWith5LinesViewModel pW5LinesVM)
        {
            // Map only fields 1:1 from ViewModel to Model  
            var result = new Prescription
            {
                Id = pW5LinesVM.Prescription.Id,
                ActionCode = pW5LinesVM.Prescription.ActionCode,
                ClientId = pW5LinesVM.Prescription.ClientId,
                DoctorId = pW5LinesVM.Prescription.DoctorId,
                PrescriptionDate = pW5LinesVM.Prescription.PrescriptionDate,
                PrescriptionDescr = pW5LinesVM.Prescription.PrescriptionDescr,
                Price = pW5LinesVM.Prescription.Price,
                CommentForDoctor = pW5LinesVM.Prescription.CommentForDoctor
            };

            return result;
        }

        internal static List<PrescriptionLine> ToPrescrLineList(this PrescrWith5LinesViewModel pW5LinesVM)
        {
            var prescrLineList = new List<PrescriptionLine>();

            if (pW5LinesVM.Line1 != null)
            {
                prescrLineList.Add(new PrescriptionLine
                {
                    PrescriptionId = pW5LinesVM.Prescription.Id,
                    Line = pW5LinesVM.Line1
                });
            }

            if (pW5LinesVM.Line2 != null)
            {
                prescrLineList.Add(new PrescriptionLine
                {
                    PrescriptionId = pW5LinesVM.Prescription.Id,  // ?????? 
                    Line = pW5LinesVM.Line2
                });
            }


            if (pW5LinesVM.Line3 != null)
            {
                prescrLineList.Add(new PrescriptionLine
                {
                    PrescriptionId = pW5LinesVM.Prescription.Id,  // ?????? 
                    Line = pW5LinesVM.Line3
                });
            }

            if (pW5LinesVM.Line4 != null)
            {
                prescrLineList.Add(new PrescriptionLine
                {
                    PrescriptionId = pW5LinesVM.Prescription.Id,  // ?????? 
                    Line = pW5LinesVM.Line4
                });
            }

            if (pW5LinesVM.Line5 != null)
            {
                prescrLineList.Add(new PrescriptionLine
                {
                    PrescriptionId = pW5LinesVM.Prescription.Id,  // ?????? 
                    Line = pW5LinesVM.Line5
                });
            }

            return prescrLineList;
        }

        //------------------------------------------------------------------------------ 

        internal static Consult ToCons(this ConsultViewModel consVM)
        {
            // Map only fields 1:1 from ViewModel to Model  
            var result = new Consult
            {
                Id = consVM.Consult.Id,
                ActionCode = consVM.Consult.ActionCode,
                ClientId = consVM.Consult.ClientId,
                DoctorId = consVM.Consult.DoctorId,
                ConsultDate = consVM.Consult.ConsultDate,
                ConsultDescr = consVM.Consult.ConsultDescr,
                Price = consVM.Consult.Price,
                CommentForDoctor = consVM.Consult.CommentForDoctor
            };

            return result;
        }

    }
}
