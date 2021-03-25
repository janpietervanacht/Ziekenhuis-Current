using System;
using System.Collections.Generic;
using System.Linq;
using Ziekenhuis.Business.Interfaces;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.Model;

namespace Ziekenhuis.Business.Managers
{
    public class DoctorManager : IDoctorManager
    {

        private readonly IDoctorRepository _doctorRepository;

        // In de constructor geven we alle objecten mee
        // die deze class zelf weer gebruikt. 

        public DoctorManager(IDoctorRepository doctorRepository)
        {
            // Bij Dependency Injection in startup.cs is geregeld
            // dat IDoctorRepository slechts één keer (lifetime) een 
            // instantie krijgt
            _doctorRepository = doctorRepository;
        }

        public Doctor GetDoctor(int doctorId)
        {
           var result =  _doctorRepository.Get(doctorId);
           return result; 
        }
    }
}
