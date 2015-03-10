using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var idcliente = Session["sesIdCliente"];
        var sesCliente = Session["sesCliente"];
        var sesNombre = Session["sesNombre"];

        if (idcliente != null)
        {
            Label1.Text = "Cliente: " + sesCliente;
        }
    }
}
