using MySql.Data.MySqlClient;

namespace ComercialTDSClass

{

    public static class Banco
    {
        public static string StrConn { get; set; }

        public static MySqlCommand Abrir(string strconn = "")
        {
            MySqlCommand cmd = new();
            StrConn = strconn;
            StrConn = $@"server=127.0.0.1;database=comercialtdsdb01;user=root;password=";
            MySqlConnection cn = new(StrConn);
            // cn.ConnectionString = StrConn;
            try
            {
                cn.Open(); // ao passar por aqui terá uma conexão aberta 
                cmd.Connection = cn;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cmd;
        }
    }
}

