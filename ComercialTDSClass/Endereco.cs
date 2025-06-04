using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;

namespace ComercialTDSClass
{
    class Endereco
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string? Cep { get;set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public string? Tipo_endereco { get; set; }
        // métodos construtores:
        public Endereco() { } // construtor vazio
        public Endereco(int id, int clienteId, string? cep, string? logradouro, string? numero, string? complemento, string? bairro, string? cidade, string? uf, string? tipo_endereco)
        {
            Id = id;
            ClienteId = clienteId;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Tipo_endereco = tipo_endereco;
        }
        public Endereco(int clienteId, string? cep, string? logradouro, string? numero, string? complemento, string? bairro, string? cidade, string? uf, string? tipo_endereco) // sem id
        {
            ClienteId = clienteId;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Tipo_endereco = tipo_endereco;
        }
        public Endereco(string? cep, string? logradouro, string? numero, string? complemento, string? bairro, string? cidade, string? uf, string? tipo_endereco) // sem id, sem clienteId
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Tipo_endereco = tipo_endereco;
        }
        // métodos:
        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_endereco_insert;";
            cmd.Parameters.AddWithValue("spcliente_id", ClienteId);
            cmd.Parameters.AddWithValue("spcep", Cep);
            cmd.Parameters.AddWithValue("splogradouro", Logradouro);
            cmd.Parameters.AddWithValue("spnumero", Numero);
            cmd.Parameters.AddWithValue("spcomplemento", Complemento);
            cmd.Parameters.AddWithValue("spbairro", Bairro);
            cmd.Parameters.AddWithValue("spcidade", Cidade);
            cmd.Parameters.AddWithValue("spuf", Uf);
            cmd.Parameters.AddWithValue("sptipo_endereco", Tipo_endereco);
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();
        }
        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_endereco_update;";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("spcep", Cep);
            cmd.Parameters.AddWithValue("splogradouro", Logradouro);
            cmd.Parameters.AddWithValue("spnumero", Numero);
            cmd.Parameters.AddWithValue("spcomplemento", Complemento);
            cmd.Parameters.AddWithValue("spbairro", Bairro);
            cmd.Parameters.AddWithValue("spcidade", Cidade);
            cmd.Parameters.AddWithValue("spuf", Uf);
            cmd.Parameters.AddWithValue("sptipo_endereco", Tipo_endereco);
            return cmd.ExecuteNonQuery() > 0 ? true : false;
        }
        public bool Deletar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_endereco_delete;";
            cmd.Parameters.AddWithValue("spid", Id);
            return cmd.ExecuteNonQuery() > 0 ? true : false;
        }
        public static List<Endereco> ObterListaGeral()
        {
            List<Endereco> listaEndereco = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from enderecos";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listaEndereco.Add(new(dr.GetInt32(0),
                            dr.GetInt32(1),
                            dr.GetString(2),
                            dr.GetString(3),
                            dr.GetString(4),
                            dr.GetString(5),
                            dr.GetString(6),
                            dr.GetString(7),
                            dr.GetString(8),
                            dr.GetString(9)
                            )
                    );
            }
            return listaEndereco;
        }
        public static List<Endereco> ObterListaPorClienteId(int clienteId)
        {
            List<Endereco> listaEndereco = new List<Endereco>();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"SELECT * FROM enderecos ORDER BY {clienteId};";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
                listaEndereco.Add(new(
                            dr.GetInt32(0), // campo id
                            dr.GetInt32(1), // campo clienteId
                            dr.GetString(2), // campo cep
                            dr.GetString(3), // campo logradouro
                            dr.GetString(4), // campo numero
                            dr.GetString(5), // campo complemento
                            dr.GetString(6), // campo bairro
                            dr.GetString(7), // campo cidade
                            dr.GetString(8),// campo uf
                            dr.GetString(9) // campo tipo_endereco
                        )
                    );
            dr.Close();
            cmd.Connection.Close();
            return listaEndereco;
        }
    }
}
