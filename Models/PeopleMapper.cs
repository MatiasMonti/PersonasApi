using AutoMapper;
using PeoplesApi.Models;
using PeoplesApi.Tables;

namespace PersonasApi.Models
{
    public class PeopleMapper : Profile
    {
        public PeopleMapper()
            {
            CreateMap<People, PeopleModel>();
            }
    }
}