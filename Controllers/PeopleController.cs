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
        public async Task<IActionResult> people()
        {
            return Ok(await this.PeopleServices.GetPeopleAsync());
        }

        [HttpGet]
        public async Task<IActionResult> shuffle()
        {
            return Ok(await this.PeopleServices.GetShuffledPersonAsync());
        }

        [HttpGet]
        public async Task<IActionResult> id([FromQuery] int IDPeople)
        {
            return Ok(await this.PeopleServices.GetPersonById(IDPeople));
        }
    }
}