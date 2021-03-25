using System;

namespace Ziekenhuis.Model
{
    public class LogDebugInfo
    {
        // In deze tabel loggen we alleen de logging-niveaus
        // Debug en Info
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
