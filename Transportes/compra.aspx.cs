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
        Panel2.Visible = false;
    }
    protected async void Button1_Click(object sender, EventArgs e)
    {
        int viajeid = int.Parse(Request.QueryString["viajeid"]);
        decimal costo = decimal.Parse(Request.QueryString["costo"]);

        ServicioTransportes.ServiceClient sc = new ServicioTransportes.ServiceClient();

        Venta sale = new Venta();
        sale.Cantidad = 1;
        sale.Asiento = "" + sale.Cantidad;
        sale.Costo = costo;
        sale.Idviaje = viajeid;
        sale.Idcliente = int.Parse(Session["sesIdCliente"].ToString());
        sale.Total = sale.Costo * sale.Cantidad;
        string values = JsonConvert.SerializeObject(sale);

        int result = sc.NuevaVenta(values);
        values = "";

        Transaccion t = new Transaccion();
        t.IdVenta = result;
        t.nombre = lblNombre.Text;
        t.Codigo = int.Parse(lblCodigo.Text);
        t.Tarjeta = lblNumero.Text;
        t.Cantidad = decimal.Parse(lblCantidad.Text);
        values = JsonConvert.SerializeObject(t);
        Label3.Text = "Esperando autorización de pago";
        Button1.Enabled = false;
        Panel1.Visible = false;

        var resultado = await sc.pagoAsync(values);
        string res = resultado.pagoResult.Rows[0].ItemArray[5].ToString();

        if (res == "S")
        {
            Panel2.Visible = true;
        }
        
        Label3.Text = "";
    }
}