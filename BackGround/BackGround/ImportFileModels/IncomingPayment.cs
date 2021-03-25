using System;

namespace Ziekenhuis.Background.ImportFileModels
{
    public class IncomingPayment
    {
        public string ReferenceFromBank { get; set; } // Referentie bepaald door de bank

        public DateTime DatePaymentCreated { get; set; }
        public string DebtorName { get; set; }

        public string DebtorIBAN { get; set; }

        // Reference bevat het functionele factuurnummer in string formaat
        // Dit wordt voor reconciliatie gebruikt
        public string PaymentReference { get; set; }

        // Ook een gedeeltelijk bedrag kan betaald worden 
        public decimal Amount { get; set; } // Alleen in euro's

                
    }
}
