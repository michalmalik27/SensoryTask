using SensoryTask.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using SensoryTask.ApiErrors;
using SensoryTask.Models.Repository;

namespace SensoryTask.Controller
{
    [Route("api/profession")]
    [ApiController]
    public class ProfessionController : ControllerBase
    {
        private readonly IProfessionRepository _ProfessionRepository;

        public ProfessionController(IProfessionRepository ProfessionRepository)
        {
            _ProfessionRepository = ProfessionRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var Professions = _ProfessionRepository.GetAll();
                return Ok(Professions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new InternalServerError(ex.Message));

            }
        }
    }
}
