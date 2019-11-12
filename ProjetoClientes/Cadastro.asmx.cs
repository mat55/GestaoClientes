using ProjetoClientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace ProjetoClientes
{
    /// <summary>
    /// Descrição resumida de Cadastro
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    // [System.Web.Script.Services.ScriptService]
    public class Cadastro : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Cliente> Lista()
        {
            return Cliente.Lista();
        }

        [WebMethod]
        public Cliente ListaUnica(string cpfCli)
        {
            return Cliente.ListaUnica(cpfCli);
        }

        [WebMethod]
        public List<Tipo_Cliente> ListaTipos()
        {
            return Tipo_Cliente.ListaTipo();
        }

        [WebMethod]
        public List<Situacao_Cliente> ListaSituacao()
        {
            return Situacao_Cliente.ListaSituacao();
        }

        [WebMethod]
        public void Insere(Models.Cliente cliente)
        {
            cliente.Insere();
        }

        [WebMethod]
        public void Altere(Models.Cliente cliente)
        {
            cliente.Altere();
        }

        [WebMethod]
        public void Delete(Models.Cliente cliente)
        {
            cliente.Delete();
        }
    }
}
