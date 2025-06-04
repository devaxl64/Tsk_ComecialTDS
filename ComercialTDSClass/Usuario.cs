using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Notice.Warning.Types;
using System.Data;

namespace ComercialTDSClass
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public Nivel? Nivel { get; set; }
        public bool Ativo { get; set; }

        // médotos construtores:
        public Usuario() // Agregação (Não deixa de existir se a referência for excluída)
        { 
            Nivel = new Nivel(); // Composição uml (Deixa de existir a se referência for excluída)
        } // construtor vazio
        public Usuario(int id, string? nome, string? email, string? senha, Nivel? nivel, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Nivel = nivel;
            Ativo = ativo;
        }
        public Usuario(string? nome, string? email, string? senha, Nivel? nivel, bool ativo) // sem id
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Nivel = nivel;
            Ativo = ativo;
        }
        public Usuario(string? nome, string? email, string? senha, Nivel? nivel) // sem id, sem ativo (geralmente usado para insert)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Nivel = nivel;
        }
        public Usuario(int id, string? senha) // Só id e senha
        {
            Id = id;
            Senha = senha;
        }
        public Usuario(int id, string? nome, string? senha, Nivel? nivel, bool ativo) // sem email
        {
            Id = id;
            Nome = nome;
            Senha = senha;
            Nivel = nivel;
            Ativo = ativo;
        }

        // métodos:
        public void Inserir() 
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_usuario_insert;";
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("spsenha", Senha);
            cmd.Parameters.AddWithValue("spnivel", Nivel.Id);
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();

        }
        public bool Atualizar() 
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_usuario_altera;";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("spsenha", Senha);
            cmd.Parameters.AddWithValue("spnivel", Nivel.Id);

            // Forma Simplificada (if ternário sem fechar conexão):
            return cmd.ExecuteNonQuery() > 0 ? true : false;

            // Forma padrão (if/else e fechando a conexão):
            //if (cmd.ExecuteNonQuery() > 0)
            //{
            //    cmd.Connection.Close();
            //    return true;
            //}
            //else
            //    return false;
        }
        public static Usuario ObterPortId(int id) 
        {
            Usuario usuario = new Usuario();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT * FROM usuarios WHERE id = {id};";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                usuario = new Usuario(
                            dr.GetInt32(0), // campo id
                            dr.GetString(1), // campo nome
                            dr.GetString(2), // campo email
                            dr.GetString(3), // campo senha
                            Nivel.ObterPorId(dr.GetInt32(4)), // campo nivel
                            dr.GetBoolean(5) // campo ativo
                    );

            }
            dr.Close();
            cmd.Connection.Close();
            return usuario;
        }
        public static List<Usuario> ObterLista(int limit=1) 
        {
            List<Usuario> usuarios = new List<Usuario>();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"SELECT * FROM usuarios ORDER BY nome;"; 
            var dr = cmd.ExecuteReader();
            while (dr.Read())
                usuarios.Add(new(
                            dr.GetInt32(0), // campo id
                            dr.GetString(1), // campo nome
                            dr.GetString(2), // campo email
                            dr.GetString(3), // campo senha
                            Nivel.ObterPorId(dr.GetInt32(4)), // campo nivel
                            dr.GetBoolean(5) // campo ativo
                        )
                    );
            return usuarios;
        }
        public static Usuario EfetuarLogin(string email, string senha) 
        {
            Usuario usuario = new Usuario();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            
            // Sem adicionar paramtreos
            cmd.CommandText = $"SELECT * FROM usuarios WHERE email = '{email}' and senha = md5('{senha}');";
            
            // Adicionando parametros com valores declarados:
            //cmd.CommandText = "select * from usuarios where email = @email and senha = md5(@senha)";
            //cmd.Parameters.AddWithValue("@email", email);
            //cmd.Parameters.AddWithValue("@senha", senha);
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                usuario = new Usuario(
                            dr.GetInt32(0), // campo id
                            dr.GetString(1), // campo nome
                            dr.GetString(2), // campo email
                            dr.GetString(3), // campo senha
                            Nivel.ObterPorId(dr.GetInt32(4)), // campo nivel
                            dr.GetBoolean(5) // campo ativo
                    );

            }
            dr.Close();
            cmd.Connection.Close();
            return usuario;
        }

        public static bool AlterarSenha(string email, string senha) 
        {
            var cmd = Banco.Abrir();
            cmd.CommandText = $"UPDATE usuarios SET senha = md5('{senha}' WHERE email = '{email}')";
            return cmd.ExecuteNonQuery() > 0 ? true : false;
        }
    }
}
