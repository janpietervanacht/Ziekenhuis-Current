using System;
using System.Collections.Generic;
using Ziekenhuis.Model;

namespace Ziekenhuis.Business.Interfaces
{
    public interface IPrescrManager
    {
        Prescription  GetPrescr(int prescrId);

        List<PrescriptionLine> GetPrescrLines(int prescrId);

        void UpdPrescrAndLines(Prescription prescr, List<PrescriptionLine> pLineList);

        void AddPrescrAndLines(Prescription prescr, List<PrescriptionLine> pLineList);

        void DelPrescr(int prescrId); // verwijdert impliciet ook de lijnen

        List<Prescription> GetAllPerClient(int cltId);

        List<Prescription> GetAllPerDoctor(int doctorId);

        List<Prescription> GetAllPerDoctorPerClient(int doctorId, int ClientId);

        List<Prescription> GetAll(); // For ADMIN
        
        
    }
}