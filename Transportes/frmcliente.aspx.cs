using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class frmcliente : System.Web.UI.Page
{
    #region PROPIEDAD GLOBAL
    ServicioTransportes.ServiceClient objWCF = new ServicioTransportes.ServiceClient();
    #endregion 

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        ClsClientes objCliente = new ClsClientes();
        objCliente.Nombre = txtNombre.Text;
        objCliente.Paterno = txtPassword.Text;
        objCliente.Materno = txtMaterno.Text;
        objCliente.Direccion = txtDireccion.Text;
        objCliente.Ciudad = txtCiudad.Text;
        objCliente.Estado = txtEstado.Text;
        objCliente.CP = int.Parse(txtCP.Text);
        objCliente.Telefono = txtTelefono.Text;
        objCliente.Correo = txtCorreo.Text;
        objCliente.Usuario = txtUsuario.Text;
        objCliente.Password = txtPassword.Text;
        bool valido = objWCF.insertCliente(JsonConvert.SerializeObject(objCliente));
        if (valido)
            Server.Transfer("mensaje.aspx");
    }
}