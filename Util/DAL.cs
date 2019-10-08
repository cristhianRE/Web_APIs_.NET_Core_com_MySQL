using MySql.Data.MySqlClient;
using System.Data;

namespace MinhaWebAPI.Util
{
    public class DAL
    {
        private static string _server = "localhost";
        private static string _database = "DBCLIENTE";
        private static string _user = "root";
        private static string _password = "";
        private MySqlConnection _connection;

        private string _connectionString = $"Server={_server}; Database={_database}; Uid={_user}; Pwd={_password};";
        
        public DAL()
        {
            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
        }

        //Executa INSERT, UPDATE, DELETE
        public void ExecutarComandoSQL(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
        }

        //Retorna dados do BD(SELECT)
        public DataTable RetornarDataTable(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, _connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;
        }
    }
}