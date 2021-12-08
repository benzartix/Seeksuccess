using Contracts;
using Contracts.Logger;
using Entites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace SeekSuccess_BackEnd.Controllers
{
    [ApiController]
    [Route("api/Account")] // route recommander
    public class AccountController : ControllerBase
    {
        //private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILoggerManager _logger;
        private IRepositoryWrapper _repoWrapper;




        public AccountController(ILoggerManager logger, IRepositoryWrapper repoWrapper)
        {
            _logger = logger;
            _repoWrapper = repoWrapper;
        }



        [HttpGet("GetAllAccount")]
        public IActionResult GetAllAccount()
        {
            try
            {
                var lAccount = _repoWrapper.Account.FindAll();
                return Ok(lAccount);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{AccountId}")]
        public IActionResult GetAccountById([FromQuery] Guid AccountId)
        {
            try
            {
                var lAccount = _repoWrapper.Account.FindByCondition(x => x.Id.Equals(AccountId));
                return Ok(lAccount);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAccountByModel")]
        public IActionResult GetAccountByModel([FromQuery] string FirstName, string LastName)
        {
            try
            {
                var lAccount = _repoWrapper.Account.FindByCondition(x =>
                FirstName != null ? x.FirstName.Equals(FirstName) : true &&
                LastName != null ? x.LastName.Equals(LastName) : true

                );
                return Ok(lAccount);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("CreateAccount")]
        public IActionResult CreateAccount([FromBody] Account account)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repoWrapper.Account.Create(account);
                    _logger.LogInfo("Account named " + account.FirstName + " " + account.LastName + " is created | " + DateTime.Now);
                    return Ok("Account named " + account.FirstName + " " + account.LastName + " is created | " + DateTime.Now);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(!ModelState.IsValid);

            }
        }

        [HttpPut("UpdateAccount")]
        public IActionResult UpdateAccount([FromBody] Account account)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repoWrapper.Account.Update(account);
                    _logger.LogInfo("Account named " + account.FirstName + " " + account.LastName + " is updated | " + DateTime.Now);
                    return Ok("Account named " + account.FirstName + " " + account.LastName + " is updated | " + DateTime.Now);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(!ModelState.IsValid);

            }
        }

        [HttpPut("AccountId")]
        public IActionResult DeleteAccount([FromQuery] Guid AccountId)
        {
            try
            {
                Account account = _repoWrapper.Account.FindByCondition(x => x.Id.Equals(AccountId)).FirstOrDefault();
                _repoWrapper.Account.Delete(account);
                _logger.LogInfo("Account named " + account.FirstName + " " + account.LastName + " is deleted | " + DateTime.Now);
                return Ok("Account named " + account.FirstName + " " + account.LastName + " is deleted | " + DateTime.Now);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpGet("GetAllCountry")]
        public IActionResult GetAllCountry()
        {
            var Country = _repoWrapper.Country.FindAll();
            return Ok(Country);
        }




        //[HttpGet("{id}", Name = "AccountById")]
        //public IActionResult GetAccountById(Guid id)
        //{
        //    _logger.LogInfo("Here is info message from the controller.");
        //    _logger.LogDebug("Here is debug message from the controller.");
        //    _logger.LogWarn("Here is warn message from the controller.");
        //    _logger.LogError("Here is error message from the controller.");


        //    return null;
        //}

        //[HttpPost]
        //public IActionResult CreateAccount([FromBody] Account account)
        //{
        //    try
        //    {
        //        if (account == null)
        //        {
        //            return BadRequest("Owner object is null");
        //        }
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest("Invalid model object");
        //        }
        //        //additional code
        //        _repoWrapper.Account.Create(account);
        //        return CreatedAtRoute("AccountById", new { id = account.Id }, account);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Exception while fetching all the students from the storage."); // simuler une exception
        //        //_logger.LogError($"Something went wrong inside the Create Account action: {ex}");
        //        //return StatusCode(500, "Internal server error");
        //    }
        //}


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
