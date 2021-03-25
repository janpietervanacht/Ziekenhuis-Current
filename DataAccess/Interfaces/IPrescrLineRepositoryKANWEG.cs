using System.Collections.Generic;
using Ziekenhuis.Model;

namespace Ziekenhuis.DataAccess.Interfaces
{
    public interface IPrescrLineRepository
    {
        List<PrescriptionLine> GetAll(); 
        void Add(PrescriptionLine prescriptionLine);
        void Update(PrescriptionLine prescriptionLine);

        void Delete(int id);

        PrescriptionLine Get(int Id);

    }
}