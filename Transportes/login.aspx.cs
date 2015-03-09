using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;

public partial class login : System.Web.UI.Page
{
    #region PROPIEDAD GLOBAL
    ServicioTransportes.ServiceClient objWCF = new ServicioTransportes.ServiceClient();
    #endregion  

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        string cliente = "";
        ClsClientes objCliente = new ClsClientes();
        objCliente.Usuario = txtUsuario.Text;
        objCliente.Password = txtPassword.Text;
        cliente = JsonConvert.SerializeObject(objCliente);
        bool existe = objWCF.exist(cliente);
        if (existe)
        {
            DataTable client = new DataTable();
            client = objWCF.session(cliente);
            Session["sesIdCliente"] = client.Rows[0]["id"].ToString();
            Session["sesCliente"] = client.Rows[0]["usuario"].ToString();
            Session["sesNombre"] = client.Rows[0]["nombre"].ToString();
            Server.Transfer("viajes.aspx");
        }
        else
            Server.Transfer("login.aspx");
    }
}