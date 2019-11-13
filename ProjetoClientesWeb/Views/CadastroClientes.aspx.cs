using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoClientesWeb.Views
{
    public partial class CadastroClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var CPF = Request.QueryString["CPF"];

            if (!IsPostBack)
            {
                if (CPF != null)
                {
                    DetalhesCliente(CPF);
                }
                else
                {
                    CarregaDropDown();
                }
            }
        }

        public void CarregaDropDown()
        {
            ClienteApi.CadastroSoapClient servico = new ClienteApi.CadastroSoapClient();

            List<ListItem> items = new List<ListItem>();

            items.Add(new ListItem("(Selecione)", ""));

            foreach (var tipos in servico.ListaTipos())
            {
                items.Add(new ListItem(tipos.Descricao, tipos.Id_Tipo_Cliente.ToString()));
            }
            dropTipo.Items.Clear();
            dropTipo.DataSource = items;
            dropTipo.DataValueField = "Value";
            dropTipo.DataTextField = "Text";
            dropTipo.DataBind();

            List<ListItem> items2 = new List<ListItem>();

            items2.Add(new ListItem("(Selecione)", ""));

            foreach (var situacao in servico.ListaSituacao())
            {
                items2.Add(new ListItem(situacao.Descricao, situacao.Id_Situacao_Cliente.ToString()));
            }

            dropSituacao.Items.Clear();
            dropSituacao.DataSource = items2;
            dropSituacao.DataValueField = "Value";
            dropSituacao.DataTextField = "Text";
            dropSituacao.DataBind();
        }

        protected void Cadastra(object sender, EventArgs e)
        {
            try
            {

                if (txtNome.Text == "")
                {
                    throw new Exception("Campo Nome é obrigatório");
                }

                if (txtCPF.Text == "")
                {
                    throw new Exception("Campo CPF é obrigatório");
                }

                if(txtCPF.Text.Length > 11)
                {
                    throw new Exception("Campo CPF deve ter no mínimo 11 caracteres");
                }

                if (rbSexoM.Checked == false && rbSexoF.Checked == false)
                {
                    throw new Exception("Campo Sexo é obrigatório");
                }

                if (dropTipo.SelectedItem == null)
                {
                    throw new Exception("Campo Tipo de Cliente é obrigatório");
                }

                if (dropSituacao.SelectedItem == null)
                {
                    throw new Exception("Campo Situação do Cliente é obrigatório");
                }

                ClienteApi.Cliente cliente = new ClienteApi.Cliente();

                cliente.CPF = txtCPF.Text;
                cliente.Nome = txtNome.Text;

                string Tipo = dropTipo.SelectedItem.Value;
                string Situacao = dropSituacao.SelectedItem.Value;

                cliente.Id_Tipo_Cliente = int.Parse(Tipo);
                cliente.Id_Situacao_Cliente = int.Parse(Situacao);

                if (rbSexoM.Checked)
                {
                    cliente.Sexo = "M";
                }
                else
                {
                    cliente.Sexo = "F";
                }

                ClienteApi.CadastroSoapClient servico = new ClienteApi.CadastroSoapClient();

                servico.Insere(cliente);
                Server.Transfer("default.aspx?Ok=Cadastrado");

            }
            catch (Exception ex)
            {
                Msg.Style.Add("display", "block");
                Msg.Attributes.Add("CssClass", "alert alert-danger alert-dismissible fade show");
                lbMsg.Text = ex.Message;
            }
        }

        protected void Atualiza(object sender, EventArgs e)
        {
            try
            {
                ClienteApi.Cliente cliente = new ClienteApi.Cliente();

                cliente.CPF = txtCPF.Text;
                cliente.Nome = txtNome.Text;

                string Tipo = dropTipo.SelectedItem.Value;
                string Situacao = dropSituacao.SelectedItem.Value;

                cliente.Id_Tipo_Cliente = int.Parse(Tipo);
                cliente.Id_Situacao_Cliente = int.Parse(Situacao);

                if (rbSexoM.Checked)
                {
                    cliente.Sexo = "M";
                }
                else
                {
                    cliente.Sexo = "F";
                }

                ClienteApi.CadastroSoapClient servico = new ClienteApi.CadastroSoapClient();

                servico.Altere(cliente);
                Response.Redirect("default.aspx?Ok=Atualizado");

            }
            catch (Exception ex)
            {
                Msg.Style.Add("display", "block");
                Msg.Attributes.Add("CssClass", "alert alert-danger alert-dismissible fade show");
                lbMsg.Text = ex.Message;
            }
        }


        public void DetalhesCliente(string cpfCli)
        {
            ClienteApi.CadastroSoapClient servico = new ClienteApi.CadastroSoapClient();

            var model = servico.ListaUnica(cpfCli);

            txtNome.Text = model.Nome;
            txtCPF.Text = model.CPF;

            txtCPF.ReadOnly = true;

            List<ListItem> items = new List<ListItem>();
            int i = 0;

            items.Add(new ListItem(model.Tipo, model.Id_Tipo_Cliente.ToString()));

            foreach (var tipos in servico.ListaTipos())
            {
                if (items[i].Text != tipos.Descricao)
                {
                    items.Add(new ListItem(tipos.Descricao, tipos.Id_Tipo_Cliente.ToString()));

                    i++;
                }
            }
            dropTipo.Items.Clear();
            dropTipo.DataSource = items;
            dropTipo.DataValueField = "Value";
            dropTipo.DataTextField = "Text";
            dropTipo.DataBind();

            List<ListItem> items2 = new List<ListItem>();
            int j = 0;

            items2.Add(new ListItem(model.Situacao, model.Id_Situacao_Cliente.ToString()));

            foreach (var situacao in servico.ListaSituacao())
            {
                if (items2[j].Text != situacao.Descricao)
                {
                    items2.Add(new ListItem(situacao.Descricao, situacao.Id_Situacao_Cliente.ToString()));
                    j++;
                }
            }

            dropSituacao.Items.Clear();
            dropSituacao.DataSource = items2;
            dropSituacao.DataValueField = "Value";
            dropSituacao.DataTextField = "Text";
            dropSituacao.DataBind();

            if (model.Sexo == "M")
            {
                rbSexoM.Checked = true;
            }
            else
            {
                rbSexoM.Checked = false;
            }
        }

        protected void Excluir(object sender, EventArgs e)
        {
            ClienteApi.CadastroSoapClient servico = new ClienteApi.CadastroSoapClient();
            ClienteApi.Cliente cliente = new ClienteApi.Cliente();

            try
            {
                cliente.CPF = txtCPF.Text;

                servico.Delete(cliente);
                Response.Redirect("default.aspx?Ok=Excluido");
            }
            catch (Exception ex)
            {
                Msg.Style.Add("display", "block");
                Msg.Attributes.Add("CssClass", "alert alert-danger alert-dismissible fade show");
                lbMsg.Text = ex.Message;
            }
        }

        protected void EsconderMsg(object sender, EventArgs e)
        {
            Msg.Style.Add("display", "none");
        }
    }
}