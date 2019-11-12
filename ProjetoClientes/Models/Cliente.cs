using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjetoClientes.Models
{
    public class Cliente
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Situacao { get; set; }
        public string Sexo { get; set; }
        public int? Id_Tipo_Cliente { get; set; }
        public int? Id_Situacao_Cliente { get; set; }

        public static List<Cliente> Lista()
        {
            var lista = new List<Cliente>();

            using (DataTable dt = Procedures.Sp_Consulta_Cliente.Exec(null).Tables[0])
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lista.Add(new Cliente()
                    {
                        CPF = dr["CPF"].ToString(),
                        Nome = dr["Nome"].ToString(),
                        Tipo = dr["Tipo"].ToString(),
                        Id_Tipo_Cliente = dr["Id_Tipo_Cliente"] != DBNull.Value ? (int?)int.Parse(dr["Id_Tipo_Cliente"].ToString()) : null,
                        Sexo = dr["Sexo"].ToString(),
                        Situacao = dr["Situacao"].ToString(),
                        Id_Situacao_Cliente = dr["Id_Situacao_Cliente"] != DBNull.Value ? (int?)int.Parse(dr["Id_Situacao_Cliente"].ToString()) : null
                    });
                }
            }

            return lista;
        }

        public static Cliente ListaUnica(string cpfCli)
        {
            using (DataTable dt = Procedures.Sp_Consulta_Cliente.Exec(cpfCli).Tables[0])
            {
                DataRow dr = dt.Rows[0];

                return new Cliente()
                {
                    CPF = dr["CPF"].ToString(),
                    Nome = dr["Nome"].ToString(),
                    Tipo = dr["Tipo"].ToString(),
                    Id_Tipo_Cliente = dr["Id_Tipo_Cliente"] != DBNull.Value ? (int?)int.Parse(dr["Id_Tipo_Cliente"].ToString()) : null,
                    Sexo = dr["Sexo"].ToString(),
                    Situacao = dr["Situacao"].ToString(),
                    Id_Situacao_Cliente = dr["Id_Situacao_Cliente"] != DBNull.Value ? (int?)int.Parse(dr["Id_Situacao_Cliente"].ToString()) : null
                };
            }
        }

        public void Insere()
        {
            Procedures.Sp_Insere_Cliente.Exec(
                    this.CPF,
                    this.Nome,
                    this.Sexo,
                    this.Id_Tipo_Cliente,
                    this.Id_Situacao_Cliente
                );
        }

        public void Altere()
        {
            Procedures.Sp_Atualiza_Cliente.Exec(
                    this.CPF,
                    this.Nome,
                    this.Sexo,
                    this.Id_Tipo_Cliente,
                    this.Id_Situacao_Cliente
                );
        }

        public void Delete()
        {
            Procedures.Sp_Exclui_Cliente.Exec(this.CPF);
        }
    }
}