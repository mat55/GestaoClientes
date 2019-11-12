using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoClientes.Procedures
{
    public class Sp_Exclui_Cliente
    {
        public static DataSet Exec(string CPF)
        {
            DataSet ds = new DataSet();

            using(SqlConnection conexao = new SqlConnection(ConfigurationManager.AppSettings["StringConexao"].ToString()))
            {
                conexao.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_Exclui_Cliente";

                cmd.Parameters.AddWithValue("@CPF", CPF != null ? (object)CPF : (object)DBNull.Value);

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