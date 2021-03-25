using System;
using System.Collections.Generic;
using System.Linq;
using Ziekenhuis.DataAccess.ApplicDbContext;
using Ziekenhuis.DataAccess.Interfaces;
using Ziekenhuis.Model;

namespace Ziekenhuis.DataAccess.Repositories
{


    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _dbContext;

         
        public DoctorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public Doctor Get(int Id)
        {
            var result = _dbContext.Doctors.Find(Id);
            return result; 
        }
    }
}
