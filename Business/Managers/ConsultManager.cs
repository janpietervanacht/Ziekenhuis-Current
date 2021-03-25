using System;
using System.Collections.Generic;
using Ziekenhuis.Business.Interfaces;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.Model;

namespace Ziekenhuis.Business.Managers
{
    public class ConsultManager : IConsultManager
    {

        private readonly IConsultRepository _consultRepository;

        // In de constructor geven we alle objecten mee
        // die deze class zelf weer gebruikt. 
        public ConsultManager(IConsultRepository consultRepository)
        {
            // Bij Dependency Injection in startup.cs is geregeld
            // dat IConsultRepository slechts één keer (lifetime) een 
            // instantie van ConsultRepository aanwijst. 
            _consultRepository = consultRepository;
        }

        public void Add(Consult consult)
        {
            _consultRepository.Add(consult); 
        }

        public void Del(int consId)
        {
            _consultRepository.Delete(consId); 
        }

        public Consult Get(int consultId)
        {
            return _consultRepository.Get(consultId); 
        }

        public List<Consult> GetAll()
        {
            var result = _consultRepository.GetAll();
            return result; 
        }

        public List<Consult> GetAllPerClient(int cltId)
        {
            throw new NotImplementedException();
        }

        public List<Consult> GetAllPerDoctor(int doctorId)
        {
            return _consultRepository.GetAllPerDoctor(doctorId);
        }

        public List<Consult> GetAllPerDoctorPerClient(int doctorId, int clientId)
        {
            return _consultRepository.GetAllPerDoctorAndPerClient(doctorId, clientId);
        }

        public int NumberOfConsultsPerClient(int clientId)
        {
            var result = _consultRepository.NumberOfConsultsPerClient(clientId);
            return result; 
        }

        public void Upd(Consult consult)
        {
            _consultRepository.Update(consult); 
        }

        // In de constructor geven we alle objecten mee
        // die deze class zelf weer gebruikt. 

    }
}
