using MySql.Data.MySqlClient;
using System;

namespace PetGramAPi.Communication.Connection
{
    public class DbConnection : IDisposable
    {
        private readonly MySqlConnection _connection;

        public DbConnection()
        {
            string connectionString = "server=localhost;database=petgram;user=root;password=savio2002";
            _connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            try
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                    Console.WriteLine("Conexão aberta com sucesso");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar: " + ex.Message);
                // Consider adding logging here
                throw; // Consider rethrowing or handling the exception appropriately
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
                Console.WriteLine("Conexão fechada com sucesso");
            }
        }

        private bool VerificationRegistration(string columnName, string value)
        {
            string query = $"SELECT COUNT(1) FROM users WHERE {columnName} = @value";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@value", value);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        public bool IsUserRegistered(string username)
        {
            return VerificationRegistration("User", username);
        }

        public bool IsPetRegistered(string petName)
        {
            return VerificationRegistration("PetName", petName);
        }

        public bool IsEmailRegistered(string email)
        {
            return VerificationRegistration("Email", email);
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }

        public void Dispose()
        {
            CloseConnection();
            _connection?.Dispose();
        }
    }
}
