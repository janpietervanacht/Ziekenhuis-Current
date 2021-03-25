using AutoMapper;
using Ziekenhuis.CRUD_API.DTO_Models;
using Ziekenhuis.Model;

// LEERMOMENT: Naam van de Namespace moet anders zijn dan de naam van de class
// Anders weet de compiler in andere sources niet of we een class of namespace bedoelen. 
// NameSpace en folder heet "ApiMapper", class heet "ApiMappings"

namespace Ziekenhuis.CRUD_API.ApiMapper
{

    public class ApiMappings : Profile
    {
        public ApiMappings()
        {
            // ReverseMap verzorgt een 2-way mapping voor de DataTransfer Objects (DTO) 
            CreateMap<Client, ClientOutgDTO>().ReverseMap();
            CreateMap<Client, ClientIncDTO>().ReverseMap();
            CreateMap<Invoice, InvoiceOutgDTO>().ReverseMap();
            CreateMap<Client, Client>(); 

        }
    }
}
