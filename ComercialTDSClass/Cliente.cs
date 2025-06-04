using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ComercialTDSClass
{
    class Cliente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public DateTime? Data_nasc { get; set; }
        public DateTime? Data_cad { get; set; }
        public bool Ativo { get; set; }
        public List<Endereco>? Enderecos { get; set; }

        // métodos construtores:
        public Cliente () { }
        public Cliente(int id, string? nome, string? cpf, string? telefone, string? email, DateTime? data_nasc, DateTime? data_cad, bool ativo, List<Endereco>? enderecos) // completo
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            Data_nasc = data_nasc;
            Data_cad = data_cad;
            Ativo = ativo;
            Enderecos = enderecos;
        }
        public Cliente(int id, string? nome, string? cpf, string? telefone, string? email, DateTime? data_nasc, DateTime? data_cad, bool ativo) // sem enderecos
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            Data_nasc = data_nasc;
            Data_cad = data_cad;
            Ativo = ativo;
        }
        public Cliente(int id, string? nome, string? cpf, string? telefone, string? email, DateTime? data_nasc, bool ativo) // sem data_cad
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            Data_nasc = data_nasc;
            Ativo = ativo;
        }
        public Cliente(string? nome, string? cpf, string? telefone, string? email, DateTime? data_nasc, DateTime? data_cad, bool ativo) // sem id
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            Data_nasc = data_nasc;
            Data_cad = data_cad;
            Ativo = ativo;
        }
        public Cliente(string? nome, string? cpf, string? telefone, string? email, DateTime? data_nasc, bool ativo) // sem id, sem data_cad
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            Data_nasc = data_nasc;
            Ativo = ativo;
        }
        public Cliente(string? nome, string? cpf, string? telefone, string? email, DateTime? data_nasc) // sem id, sem data_cad, sem ativo
        { // Este é o construtor que ultilizaremos para inserir o cliente
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            Data_nasc = data_nasc;
        }
        public Cliente(string? nome, string? cpf, string? telefone, string? email) // sem id, sem data_cad, sem data_nasc, sem ativo
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
        }

        // métodos:
        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_cliente_insert;";
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("spcpf", Cpf);
            cmd.Parameters.AddWithValue("sptelefone", Telefone);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("spdatanasc", Data_nasc);
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();

        }
        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_cliente_update;";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("sptelefone", Telefone);
            cmd.Parameters.AddWithValue("spdatanasc", Data_nasc);

            // Forma Simplificada (if ternário sem fechar conexão):
            return cmd.ExecuteNonQuery() > 0 ? true : false;
        }
        public static Cliente ObterPortId(int id)
        {
            Cliente listaCliente = new Cliente();
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT * FROM clientes WHERE id = {id};";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                listaCliente = new(
                            dr.GetInt32(0), // campo id
                            dr.GetString(1), // campo nome
                            dr.GetString(2), // campo cpf
                            dr.GetString(3), // campo telefone
                            dr.GetString(4), // campo email
                            dr.GetDateTime(5), // campo data_nasc
                            dr.GetDateTime(6), // campo data_cad
                            dr.GetBoolean(7), // campo ativo
                            Endereco.ObterListaPorClienteId(dr.GetInt32(0)) // campo endereço
                    );
            }
            dr.Close();
            cmd.Connection.Close();
            return listaCliente;
        }
        public static List<Cliente> ObterListaPorCliente(int limit = 1) 
        {
            List<Cliente> listaCliente = new List<Cliente>();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"SELECT * FROM clientes ORDER BY nome;"; 
            var dr = cmd.ExecuteReader();
            while (dr.Read())
                listaCliente.Add(new(
                            dr.GetInt32(0), // campo id
                            dr.GetString(1), // campo nome
                            dr.GetString(2), // campo cpf
                            dr.GetString(3), // campo telefone
                            dr.GetString(4), // campo email
                            dr.GetDateTime(5), // campo data_nasc
                            dr.GetDateTime(6), // campo data_cad
                            dr.GetBoolean(7), // campo ativo
                            Endereco.ObterListaPorClienteId(dr.GetInt32(0)) // campo endereço
                        )
                    );
            dr.Close();
            cmd.Connection.Close();
            return listaCliente;
        }
    }
}
