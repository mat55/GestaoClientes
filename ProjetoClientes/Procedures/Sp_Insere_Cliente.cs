using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoClientes.Procedures
{
    public class Sp_Insere_Cliente
    {
        public static DataSet Exec(
                string Nome,
                string CPF,
                string Sexo,
                int? Id_Tipo_Cliente,
                int? Id_Situacao_Cliente
            )
        {
            DataSet ds = new DataSet();

            using (SqlConnection conexao = new SqlConnection(ConfigurationManager.AppSettings["StringConexao"].ToString()))
            {
                conexao.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_Insere_Cliente";

                cmd.Parameters.AddWithValue("@Nome", Nome != null ? (object)Nome : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CPF", CPF != null ? (object)CPF : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Sexo", Sexo != null ? (object)Sexo : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Id_Tipo_Cliente", @Id_Tipo_Cliente != null ? (object)@Id_Tipo_Cliente : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Id_Situacao_Cliente", Id_Situacao_Cliente != null ? (object)Id_Situacao_Cliente : (object)DBNull.Value);

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