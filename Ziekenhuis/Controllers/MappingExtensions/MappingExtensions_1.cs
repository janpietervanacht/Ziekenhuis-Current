using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ziekenhuis.Model;
using Ziekenhuis.Ziekenhuis.ViewModels;

// Deze class bevat extension methods om de default
// velden van de ModelView te vullen. 

namespace Ziekenhuis.Ziekenhuis.Controllers.MappingExtensions
{
    public static partial class MappingExtension
        // In een static class zijn alle properties/methods ook static
    {
        internal static List<ClientViewModel> ToClientVMList(this List<Client> list)
        {
            // Onderstaande is niet volledig: retourneert IEnumerable<ClientViewModel>
            // var x =  list1.Select(c1 => c1.ToClientVM());

            // result is een IList<ClientViewModel>, erft van IEnumerable 
            var result = list.Select(c => c.ToClientVM()).ToList();
            return result; 

            // Doet hetzelfde als hieronder:
            //for (int i = 0; i < list1.Count; i++)
            //{
            //    var c2 = list1[i].MapClient2VM();
            //    list2.Add(c2); 
            //}
        }

        internal static ClientViewModel ToClientVM(this Client clt)
        {
            // Map only standard fields 1:1 from Model to ViewModel  

            var result = new ClientViewModel
            {
                Client = new Client
                {
                    Id = clt.Id,
                    DoctorId = clt.DoctorId,
                    ActionCode = clt.ActionCode,
                    IsInsured = clt.IsInsured, 
                    Gender = clt.Gender,
                    ClientNumber = clt.ClientNumber, 
                    FirstName = clt.FirstName,
                    LastName = clt.LastName,
                    Street = clt.Street,
                    HouseNumber = clt.HouseNumber,
                    PostalCode = clt.PostalCode,
                    City = clt.City,
                    CountryId = clt.CountryId, 
                    Country = clt.Country,
                    BirthDate = clt.BirthDate,
                    BudgetAvaiable = clt.BudgetAvaiable,
                    BudgetSpent = clt.BudgetSpent,
                    CommentForDoctor = clt.CommentForDoctor,
                    PolicyNumber = clt.PolicyNumber
                }
                
            };

            return result; 

        }

        internal static Client ToClient(this ClientViewModel cltVM)
        {
            // Map only fields 1:1 from ViewModel to Model  
            var result = new Client
            {
                Id = cltVM.Client.Id,
                DoctorId = cltVM.Client.DoctorId,
                ActionCode = cltVM.Client.ActionCode,
                IsInsured = cltVM.Client.IsInsured, 
                Gender = cltVM.Client.Gender,
                ClientNumber = cltVM.Client.ClientNumber, 
                FirstName = cltVM.Client.FirstName,
                LastName = cltVM.Client.LastName,
                Street = cltVM.Client.Street,
                HouseNumber = cltVM.Client.HouseNumber,
                PostalCode = cltVM.Client.PostalCode,
                City = cltVM.Client.City,
                CountryId = cltVM.Client.CountryId,
                Country = cltVM.Client.Country,
                BirthDate = cltVM.Client.BirthDate,
                BudgetAvaiable = cltVM.Client.BudgetAvaiable,
                BudgetSpent = cltVM.Client.BudgetSpent,
                CommentForDoctor = cltVM.Client.CommentForDoctor,
                PolicyNumber = cltVM.Client.PolicyNumber
            };

            return result; 
        }

        
        //------------------------------------------------------------------- 



    }
}
