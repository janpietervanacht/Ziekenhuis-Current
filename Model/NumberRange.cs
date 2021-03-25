using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ziekenhuis.Model
{
    public class NumberRange
    {
        public int Id { get; set; }

        public int MinClientNumber { get; set; }

        public int MaxClientNumber { get; set; }

        public int CurrentClientNumber { get; set; }

        public int MinInvoiceNumber { get; set; }

        public int MaxInvoiceNumber { get; set; }

        public int CurrentInvoiceNumber { get; set; }

    }
}
