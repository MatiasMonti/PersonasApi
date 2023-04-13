using PersonasApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace PeoplesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleServices PeopleServices;

        public PeopleController(IPeopleServices cPeopleServices)
        {
            this.PeopleServices = cPeopleServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            return Ok(await this.PeopleServices.GetPeopleAsync());
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Shuffle()
        {
            return Ok(await this.PeopleServices.GetShuffledPersonAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            return Ok(await this.PeopleServices.GetPersonById(id));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await this.PeopleServices.DeletePerson(id);
            return Ok();
        }
    }
}