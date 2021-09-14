// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using System.Collections.Generic;
    using System.Linq;

    [Route("[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> logger;
        private readonly PeopleService peopleService;

        public PeopleController(ILogger<PeopleController> logger, PeopleService peopleService)
        {
            this.logger = logger;
            this.peopleService = peopleService;
        }

        // GET: People
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return peopleService.People;
        }

        // GET People/Adam&Nörd
        [HttpGet("person/{name}&{title}")]
        public Person Get(string name, string title)
        {
            return peopleService.People.First(p => p.Name == name && p.Title == title);
        }

        // POST People
        [HttpPost]
        public void Post([FromBody] Person person)
        {
            logger.LogInformation($"{person.Name} - {person.Title}");
            peopleService.People.Add(person);
        }

        // PUT People/Adam
        [HttpPut("{name}")]
        public void Put(string name, [FromBody] Person person)
        {
            Person p = peopleService.People.First(p => p.Name == name);
            p.Name = person.Name;
            p.Title = person.Title;
        }

        // DELETE People/5
        [HttpDelete("{name}")]
        public void Delete(string name)
        {
            Person p = peopleService.People.First(p => p.Name == name);
            peopleService.People.Remove(p);
        }
    }
}
