using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoClientes.Procedures
{
    public class Sp_Consulta_Situacao_Cliente
    {
        public static DataSet Exec()
        {
            DataSet ds = new DataSet();

            using (SqlConnection conexao = new SqlConnection(ConfigurationManager.AppSettings["StringConexao"].ToString()))
            {
                conexao.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_Consulta_Situacao_Cliente";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                da.Dispose();
                cmd.Dispose();
                conexao.Close();
            }

            return ds;
        }
    }
}