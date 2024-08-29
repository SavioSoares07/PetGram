using Microsoft.AspNetCore.Mvc;
using PetGramAPi.Communication.Connection;
using PetGramAPi.Communication.Excepetion;
using PetGramAPi.Communication.Request;
using FluentValidation.Results;
using System.Linq;
using MySql.Data.MySqlClient;

namespace PetGramAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Account : ControllerBase
    {
        private readonly DbConnection _dbConnection;

        public Account(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

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

            try
            {
                _dbConnection.OpenConnection();

                if (_dbConnection.IsEmailRegistered(account.Email)) {
                    return Conflict("Email ja cadastrado");
                }

                string insertQuery = "INSERT INTO users (User, PetName, Email, Password) VALUES (@USer, @PetName, @Email, @Password)";
                MySqlCommand command = new MySqlCommand(insertQuery, _dbConnection.GetConnection());

                command.Parameters.AddWithValue("@User", account.User);
                command.Parameters.AddWithValue("@PetName", account.PetName);
                command.Parameters.AddWithValue("@Email", account.Email);
                command.Parameters.AddWithValue("@Password", account.Password);

                // Executa o comando
                command.ExecuteNonQuery();

                return Created(string.Empty, account);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno: " + ex.Message);
            }
            finally
            {
                _dbConnection.CloseConnection();
            }
        }
    }
}
