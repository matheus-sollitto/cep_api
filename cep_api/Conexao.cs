using MySql.Data.MySqlClient;

namespace cep_api
{
    internal class Conexao
    {
        private MySqlConnection con;
        public string data_source = "datasource = localhost; username = root; passwors =; database = cep;";

        //insere no banco de dados
        public void Insert(string query)
        {
            con = new MySqlConnection(data_source);

            con.Open();

            MySqlCommand comando = new MySqlCommand(query, con);

            comando.ExecuteReader();

            con.Close();
        }

    }
}
