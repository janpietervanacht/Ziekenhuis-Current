using System.Collections.Generic;
using Ziekenhuis.Model;

namespace Ziekenhuis.Business.Interfaces
{
    public interface IDoctorManager
    {
        Doctor GetDoctor (int doctorId);
        // We bouwen geen onderhoudsfunctie
        // voor doctoren, want er zijn er
        // maar een paar. 

        
    }
}