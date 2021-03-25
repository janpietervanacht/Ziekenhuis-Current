using System;

namespace Ziekenhuis.Model
{
    public class LogApiError
    {
        // In deze tabel loggen we alleen de logging-niveau Error
        // Alleen de API gebruikt deze tabel, daarom heeft project
        // CRUD-API zijn eigen logging configuratie
        public int Id { get; set; }
        public string Application { get; set; }
        public DateTime Logged { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Logger { get; set; }
        public string Callsite { get; set; }
        public string Exception { get; set; }

    }
}
