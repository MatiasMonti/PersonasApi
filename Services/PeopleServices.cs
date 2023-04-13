using AutoMapper;
using PeoplesApi.Aplication;
using PeoplesApi.Models;
using PeoplesApi.Tables;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<PeopleModel>> GetPeopleAsync()
        {
            List<People> lisPeople = await Context.People.ToListAsync();

            return this.Mapper.Map<List<People>, List<PeopleModel>>(lisPeople);
        }
         
        public async Task<PeopleModel> GetShuffledPersonAsync()
        {
            People shuffledPerson = await Context.People.OrderBy(r => Guid.NewGuid()).FirstAsync();

            return this.Mapper.Map<People, PeopleModel>(shuffledPerson);
        }
         
        public async Task<PeopleModel> GetPersonById(int IDPeople)
        {
            People? shuffledPerson = await Context.People.FindAsync(IDPeople);

            nullValidator(shuffledPerson);

            return this.Mapper.Map<People, PeopleModel>(shuffledPerson);
        }

        public async Task DeletePerson(int IDPeople)
        {
            People? ToDeletePerson = await Context.People.FindAsync(IDPeople);

            nullValidator(ToDeletePerson);

            Context.People.Remove(ToDeletePerson);

            await Context.SaveChangesAsync();
        }

        private void nullValidator(People? entPeople)
        {
            if (entPeople == null)
            {
                throw new Exception("No se encontro el usuario");
            }
        }
    }

    public interface IPeopleServices
    {
        public Task<List<PeopleModel>> GetPeopleAsync();
        public Task<PeopleModel> GetPersonById(int IDPeople);
        public Task<PeopleModel> GetShuffledPersonAsync();
        public Task DeletePerson(int IDPeople);
    }
}
