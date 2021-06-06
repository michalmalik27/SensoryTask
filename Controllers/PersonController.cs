using SensoryTask.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using SensoryTask.Services;
using SensoryTask.ApiErrors;

namespace SensoryTask.Controller
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var persons = _personService.GetAll();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new InternalServerError(ex.Message));

            }
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                Person person = _personService.Get(id);
                if (person == null)
                {
                    return NotFound(new NotFoundError("The person not exists."));
                }
                return Ok(person);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new InternalServerError(ex.Message));
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            try
            {
                if (person == null)
                {
                    return BadRequest(new BadRequestError("Person is null."));
                }

                _personService.Add(person);
                return CreatedAtRoute(
                      "Get",
                      new { Id = person.PersonId },
                      person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new InternalServerError(ex.Message));
            }
        }
    }
}
