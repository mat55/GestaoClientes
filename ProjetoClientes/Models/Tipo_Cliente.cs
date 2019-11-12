using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjetoClientes.Models
{
    public class Tipo_Cliente
    {
        public int? Id_Tipo_Cliente { get; set; }
        public string Descricao { get; set; }

        public static List<Tipo_Cliente> ListaTipo()
        {
            var lista = new List<Tipo_Cliente>();

            using (DataTable dt = Procedures.Sp_Consulta_Tipo_Cliente.Exec().Tables[0])
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lista.Add(new Tipo_Cliente()
                    {
                        Id_Tipo_Cliente = dr["Id_Tipo_Cliente"] != DBNull.Value ? (int?)int.Parse(dr["Id_Tipo_Cliente"].ToString()) : null,
                        Descricao = dr["Descricao"].ToString()
                    });
                }
            }

            return lista;
        }
    }
}