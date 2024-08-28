using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetGramAPi.Communication.Excepetion;
using PetGramAPi.Communication.Request;
using FluentValidation.Results;
using System.Linq;

namespace PetGramAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Account : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] RequestAccount account)
        {
            var validator = new AccountExcpetion();

            ValidationResult result = validator.Validate(account);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(error => error.ErrorMessage).ToList();

                return BadRequest(errors);
            }

            return Created(string.Empty, account);
        }
    }
}
