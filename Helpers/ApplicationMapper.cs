using API1.Data;
using API1.Models;
using AutoMapper;

namespace API1.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<Book, BookModels>().ReverseMap();
        }
    }
}
