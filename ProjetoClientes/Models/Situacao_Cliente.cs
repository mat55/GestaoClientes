using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjetoClientes.Models
{
    public class Situacao_Cliente
    {
        public int? Id_Situacao_Cliente { get; set; }
        public string Descricao { get; set; }

        public static List<Situacao_Cliente> ListaSituacao()
        {
            var lista = new List<Situacao_Cliente>();

            using (DataTable dt = Procedures.Sp_Consulta_Situacao_Cliente.Exec().Tables[0])
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lista.Add(new Situacao_Cliente()
                    {
                        Id_Situacao_Cliente = dr["Id_Situacao_Cliente"] != DBNull.Value ? (int?)int.Parse(dr["Id_Situacao_Cliente"].ToString()) : null,
                        Descricao = dr["Descricao"].ToString()
                    });
                }
            }

            return lista;
        }
    }
}