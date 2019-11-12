using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClientesWeb.Views
{
    public partial class ConsultaClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AbreGrid();
        }

        public void AbreGrid()
        {
            ClienteApi.CadastroSoapClient servico = new ClienteApi.CadastroSoapClient();

            var model = servico.Lista();

            DataTable dt = new DataTable();
            dt.Columns.Add("CPF");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Tipo do Cliente");
            dt.Columns.Add("Sexo");
            dt.Columns.Add("Situação do Cliente");

            for (int i = 0; i < model.Length; i++)
            {
                dt.Rows.Add(
                    model[i].CPF,
                    model[i].Nome,
                    model[i].Tipo,
                    model[i].Sexo,
                    model[i].Situacao
                    );
            }

            GridViewClientes.DataSource = dt;
            GridViewClientes.DataBind();

            switch (Request.QueryString["Ok"])
            {
                case "Cadastrado":
                    Msg.Style.Add("display", "block");
                    Msg.Attributes["class"] = "alert alert-success alert-dismissible fade show";
                    lbMsg.Text = "Cliente cadastrado com sucesso";

                    break;
                case "Atualizado":
                    Msg.Style.Add("display", "block");
                    Msg.Attributes["class"] = "alert alert-success alert-dismissible fade show";
                    lbMsg.Text = "Cliente alterado com sucesso";

                    break;
                case "Excluido":
                    Msg.Style.Add("display", "block");
                    Msg.Attributes["class"] = "alert alert-success alert-dismissible fade show";
                    lbMsg.Text = "Cliente excluido com sucesso";

                    break;
            }
        }

        protected void EsconderMsg(object sender, EventArgs e)
        {
            Msg.Style.Add("display", "none");
        }

        protected void GridViewClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}