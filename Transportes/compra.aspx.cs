using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class compra : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var viajeid = Request.QueryString["viajeid"];
        var costo = Request.QueryString["costo"];

        ServicioTransportes.ServiceClient sc = new ServicioTransportes.ServiceClient();

        Venta sale = new Venta();
        sale.Cantidad = 1;
        sale.Asiento = "" + sale.Cantidad;
        sale.Costo = decimal.Parse(costo);
        sale.Idviaje = int.Parse(viajeid);
        sale.Idcliente = int.Parse(Session["sesIdCliente"].ToString());
        sale.Total = sale.Costo * sale.Cantidad;
        string values = JsonConvert.SerializeObject(sale);

        int result = sc.NuevaVenta(values);
    }
}