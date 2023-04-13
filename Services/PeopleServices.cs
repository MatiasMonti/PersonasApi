using AutoMapper;
using PeoplesApi.Aplication;
using PeoplesApi.Models;
using System.Data.Entity;

namespace PersonasApi.Services
{
    public class PeopleServices : IPeopleServices
    {
        private readonly AplicationDBContext Context;
        private readonly IMapper Mapper;

        public PeopleServices(AplicationDBContext cContext, IMapper cMapper)
        {
            this.Context = cContext;
            this.Mapper = cMapper;
        }

        public async Task<List<People>> GetPeopleAsync()
        {
            List<People> lisPeople = await Context.People.ToListAsync();

            return lisPeople;
        }
         
        public async Task<People> GetShuffledPersonAsync()
        {
            People shuffledPerson = await Context.People.OrderBy(r => Guid.NewGuid()).FirstAsync();

            return shuffledPerson;
        }
         
        public async Task<People> GetPersonById(int IDPeople)
        {
            People shuffledPerson = await Context.People.Where(r => r.ID == IDPeople).FirstAsync();

            return shuffledPerson;
        }
    }
    public interface IPeopleServices
    {
        public Task<List<People>> GetPeopleAsync();
        Task<object?> GetPersonById(int IDPeople);
        Task<object?> GetShuffledPersonAsync();
    }
}
