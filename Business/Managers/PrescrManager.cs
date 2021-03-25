using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ziekenhuis.Business.Interfaces;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.Model;

namespace Ziekenhuis.Business.Managers
{
    public class PrescrManager : IPrescrManager
    {

        private readonly IPrescrRepository _prescrRepository;

        // In de constructor geven we alle objecten mee
        // die deze class zelf weer gebruikt. 
        public PrescrManager(IPrescrRepository prescrRepository)
        {
            // Bij Dependency Injection in startup.cs is geregeld
            // dat IPrescrRepository slechts één keer (lifetime) een 
            // instantie van PrescrRepository aanwijst. 
            _prescrRepository = prescrRepository;
        }


        public void DelPrescr(int prescrId)
        {
            // Verwijder eerst de lijnen, daarna de header
            // Als je het andersom doet: dan is de database tijdelijk niet integer
            _prescrRepository.DeleteAllLines(prescrId);
            _prescrRepository.Delete(prescrId);
            
        }

        public Prescription GetPrescr(int prescrId)
        {
            var prescr = _prescrRepository.Get(prescrId);
            return prescr;
        }

        public List<PrescriptionLine> GetPrescrLines(int prescrId)
        {
            var plines = _prescrRepository.GetPLines(prescrId);
            return plines;
        }

        public List<Prescription> GetAll()
        {
            var result = _prescrRepository.GetAll();
            return result;
        }

        public List<Prescription> GetAllPerClient(int cltId)
        {
            return _prescrRepository.GetAllPerClient(cltId);
        }

        public List<Prescription> GetAllPerDoctor(int doctorId)
        {
            return _prescrRepository.GetAllPerDoctor(doctorId);
        }

        public List<Prescription> GetAllPerDoctorPerClient(int doctorId, int clientId)
        {
            return _prescrRepository.GetAllPerDoctorAndPerClient(doctorId, clientId);
        }

        public void UpdPrescrAndLines(Prescription prescr, List<PrescriptionLine> pLineList)
        {
            _prescrRepository.Upd(prescr, pLineList);
        }


        //  public void Add(Prescription prescr, List<PrescriptionLine> plineList)
        public void AddPrescrAndLines(Prescription prescr, List<PrescriptionLine> pLineList)
        {
            _prescrRepository.Add(prescr, pLineList); 
        }

        // In de constructor geven we alle objecten mee
        // die deze class zelf weer gebruikt. 

    }
}
