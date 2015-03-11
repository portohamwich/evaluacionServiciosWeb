using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class compra : System.Web.UI.Page
{
    #region VARIABLE GLOBAL
    List<ClsDescuento> lstDescuento = null;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        if (!Page.IsPostBack)
            Descuentos();
    }
    protected async void Button1_Click(object sender, EventArgs e)
    {
        int viajeid = int.Parse(Request.QueryString["viajeid"]);
        decimal costo = decimal.Parse(Request.QueryString["costo"]);

        ServicioTransportes.ServiceClient sc = new ServicioTransportes.ServiceClient();

        ///SE APLICA EL DESCUENTO
        int idDesc = int.Parse(ddlDescuento.SelectedValue);
        if (idDesc != 0)
        {
            Descuentos();
            var _des = (from d in lstDescuento where d.Id == idDesc select new { d.Descuento }).ToList();
            decimal total = decimal.Parse(lblCantidad.Text) * costo;
            decimal descuento = decimal.Parse(_des[0].Descuento.ToString());
            costo = total - (total * descuento);
        }

        Venta sale = new Venta();
        sale.Cantidad = int.Parse(lblCantidad.Text);
        sale.Asiento = "" + sale.Cantidad;
        sale.Costo = costo;
        sale.Idviaje = viajeid;
        sale.Idcliente = int.Parse(Session["sesIdCliente"].ToString());
        sale.Total = costo;
        sale.Iddescuento = idDesc;
        string values = JsonConvert.SerializeObject(sale);

        int result = sc.NuevaVenta(values);
        values = "";

        Transaccion t = new Transaccion();
        t.IdVenta = result;
        t.nombre = lblNombre.Text;
        t.Codigo = int.Parse(lblCodigo.Text);
        t.Tarjeta = lblNumero.Text;
        t.Cantidad = costo;
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

    protected void Descuentos()
    {
        ServicioTransportes.ServiceClient sc = new ServicioTransportes.ServiceClient();
        string priceoff = sc.getDescuentos();
        lstDescuento = JsonConvert.DeserializeObject<List<ClsDescuento>>(priceoff);
        var desc = JsonConvert.DeserializeObject<List<ClsDescuento>>(priceoff);
        var _res = from d in desc select new { d.Id, descuento = d.NombreCorto + " - " + d.Descuento };
        ddlDescuento.DataSource = _res.ToList();
        ddlDescuento.DataTextField = "descuento";
        ddlDescuento.DataValueField = "id";
        ddlDescuento.DataBind();
    }
}