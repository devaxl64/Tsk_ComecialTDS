using System.Data;
using MySql.Data.MySqlClient;

namespace ComercialTDSClass
{
    public class Nivel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sigla { get; set; }
        public Nivel() { }
        public Nivel(int id, string nome, string sigla)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
        }
        public Nivel(string nome, string sigla)
        {
            Nome = nome;
            Sigla = sigla;
        }
        // Inserir, Atualizar, Listar ObterPorId(id)

        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = $"sp_nivel_insert;";
            //cmd.Parameters.Add("spnome", MySqlDbType.VarChar).Value = Nome; // Mesmo Comando da linha abaixo
            cmd.Parameters.AddWithValue("spnome", Nome); // Mesmo Comando
            cmd.Parameters.AddWithValue("spsigla", Sigla);
            // Pode ser usado um execute reader também (var dr...)
            // mas o 'Scalar' também é bom.
            Id = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public static Nivel ObterPorId(int id)
        {
            Nivel nivel = new Nivel();
            // código do método (estudar sobre conceitos do método ex: 'static', 'void' etc)
            var cmd = Banco.Abrir();
            // Mostra o resultado de uma busca: (data reader)
            cmd.CommandText = $"SELECT * FROM niveis WHERE id = {id}";
            
            var dr = cmd.ExecuteReader();
            // pode ser usado o if quando já se sabe o que precisa
            // while quando não se sabe ao certo o que você precisa
            if (dr.Read())
            {
                // Conseitual (Quando eu sei o que estou fazendo)
                nivel.Id = dr.GetInt32(0);
                nivel.Nome = dr.GetString(1);
                nivel.Sigla = dr.GetString(2);
                // Pode ser usado assim: (Mas não é profissional)
                //nivel = new(dr.GetInt32(0), dr.GetString(1), dr.GetString(2));
            }
            // para não dar problema eu posso usar um dr.close para fechar o cmd
            // e fechar a conexão: (cmd.Connectio.Close();)
            dr.Close();
            cmd.Connection.Close();

            return nivel;
        }
        public static List<Nivel> ObterLista()
        {
            // Aqui só isso já funciona, mas não retorna nada.
            //List<Nivel> niveis = new List<Nivel>();
            //return niveis; 
            
            // Aqui a lista para retornar a lista do db:
            List<Nivel> niveis = new List<Nivel>();
            var cmd = Banco.Abrir();
            cmd.CommandText = "SELECT * FROM niveis ORDER BY nome;";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                niveis.Add(new(dr.GetInt32(0), dr.GetString(1), dr.GetString(2)));
            }
            // mantendo a boa pratica de fechar o DataReader e a Conexão:
            dr.Close();
            cmd.Connection.Close();

            return niveis;
        }
        public bool Atualizar()
        {
            // como este método não é estatico (static) 
            // precisamos considerar que as propriedades já possuem valores atribuidos
            bool atualizado = false;
            if (Id < 1 )
            {
                return atualizado; // é a mesma coisa que 'return false;'
            }
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = $"sp_nivel_update";
            cmd.Parameters.AddWithValue("spid", Id); // (romevido), pois não se atualiza o id --> // Readicionado pois, não é possível editar sem localizar o 'spid'.
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("spsigla", Sigla);
            // retorna tipo inteiro que é equivalente o número de linhas afetadas
            // para 'update' 'insert' ou 'delete' o retorno é o número de linhas afetadas
            // para os demais comandos o retorno 0 linhas afetadas, quer dizer que não 
            if (cmd.ExecuteNonQuery()>0)
            {
                atualizado = true;
            }
            cmd.Connection.Close();
            return atualizado;
        }
    }
}