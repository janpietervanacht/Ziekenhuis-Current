using System.Collections.Generic;
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

        internal static Invoice ToInvoice(this InvoiceViewModel invVM)
        {
            // Map only fields 1:1 from ViewModel to Model  
            var result = new Invoice
            {
                Id = invVM.Invoice.Id, 
                ActionCode = invVM.Invoice.ActionCode,
                InvoiceNumber = invVM.Invoice.InvoiceNumber,
                Status = invVM.Invoice.Status,
                SendYN = invVM.Invoice.SendYN,
                ClientId = invVM.Invoice.ClientId,
                DoctorId = invVM.Invoice.DoctorId,
                DueDate = invVM.Invoice.DueDate,
                InvoiceDescription = invVM.Invoice.InvoiceDescription,
                Amount = invVM.Invoice.Amount,
                CommentForDoctor = invVM.Invoice.CommentForDoctor
            };

            return result;
        }

        internal static List<InvoiceLine> ToInvoiceLineList(this InvoiceViewModel invVM)
        {
            var invLineList = new List<InvoiceLine>();

            if (invVM.Line1 != null)
            {
                invLineList.Add(new InvoiceLine
                {
                    InvoiceId = invVM.Invoice.Id,
                    Line = invVM.Line1
                });
            }

            if (invVM.Line2 != null)
            {
                invLineList.Add(new InvoiceLine
                {
                    InvoiceId = invVM.Invoice.Id,
                    Line = invVM.Line2
                });
            }

            if (invVM.Line3 != null)
            {
                invLineList.Add(new InvoiceLine
                {
                    InvoiceId = invVM.Invoice.Id,
                    Line = invVM.Line3
                });
            }

            return invLineList;
        }

    }
}
