using MySql.Data.MySqlClient;

namespace PetGramAPi.Communication.Connection
{
    public class DbConnection
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
                _connection.Open();
                Console.WriteLine("Conexão aberta com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
                Console.WriteLine("Conexão fechada com sucesso");
            }
        }

        public bool IsEmailRegistered(string email)
        {
            string query = "SELECT COUNT(1) FROM users Where Email = @Email";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Email", email);

            int countEmail = Convert.ToInt32(command.ExecuteScalar());
            return countEmail > 0;
        }
        public MySqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
