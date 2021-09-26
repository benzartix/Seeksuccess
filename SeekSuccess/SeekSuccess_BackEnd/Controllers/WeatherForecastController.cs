using Contracts;
using Contracts.Logger;
using Entites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeekSuccess_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILoggerManager _logger;


        private IRepositoryWrapper _repoWrapper;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public WeatherForecastController(ILoggerManager logger, IRepositoryWrapper repoWrapper)
        {
            _logger = logger;
            _repoWrapper = repoWrapper;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet]
        public IActionResult GetAllAccount()
        {
            var Account = _repoWrapper.Account.FindByCondition(x => x.LastName.Equals("Ahmed"));
            var Country = _repoWrapper.Country.FindAll();
            return null;
        }
        [HttpGet("{id}", Name = "AccountById")]
        public IActionResult GetAccountById(Guid id)
        {
            _logger.LogInfo("Here is info message from the controller.");
            _logger.LogDebug("Here is debug message from the controller.");
            _logger.LogWarn("Here is warn message from the controller.");
            _logger.LogError("Here is error message from the controller.");


            return null;
        }

        [HttpPost]
        public IActionResult CreateAccount([FromBody] Account account)
        {
            try
            {
                if (account == null)
                {
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                //additional code
                _repoWrapper.Account.Create(account);
                return CreatedAtRoute("AccountById", new { id = account.Id }, account);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while fetching all the students from the storage."); // simuler une exception
                //_logger.LogError($"Something went wrong inside the Create Account action: {ex}");
                //return StatusCode(500, "Internal server error");
            }
        }


        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
