using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class consulta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            listas();
    }

    protected void listas()
    {
        ServicioTransportes.ServiceClient sc = new ServicioTransportes.ServiceClient();
        string categorias = sc.getCategorias();
        var cat = JsonConvert.DeserializeObject<List<ClsCategoria>>(categorias);
        ddlCategoria.DataSource = cat.ToList();
        ddlCategoria.DataTextField = "categoria";
        ddlCategoria.DataValueField = "id";
        ddlCategoria.DataBind();

        string descuentos = sc.getDescuentos();
        var desc = JsonConvert.DeserializeObject<List<ClsDescuento>>(descuentos);
        var _desc = from d in desc select new { d.Id, descuento = d.NombreCorto + " - " + d.Descuento };
        ddlDescuento.DataSource = _desc.ToList();
        ddlDescuento.DataTextField = "descuento";
        ddlDescuento.DataValueField = "id";
        ddlDescuento.DataBind();

        string rutas = sc.getRoutes();
        var rut = JsonConvert.DeserializeObject<List<Ruta>>(rutas);
        var _r = from a in rut select new { a.id, ruta = a.Origen + " - " + a.Destino };
        ddlRuta.DataSource = _r.ToList();
        ddlRuta.DataTextField = "ruta";
        ddlRuta.DataValueField = "id";
        ddlRuta.DataBind();
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        string _categoria = ddlCategoria.SelectedValue;
        string _descuento = ddlDescuento.SelectedValue;
        string _ruta = ddlRuta.SelectedValue;
        string _fechaini = txtFechaIni.Text;
        string _fechafin = txtFechaFin.Text;
        string _tarjeta = "";

        if (txtTarjeta.Text.Length.Equals(0))
            _tarjeta = "0";
        else
            _tarjeta = txtTarjeta.Text;

        ClsConsulta objDato = new ClsConsulta();
        objDato._categoria = _categoria;
        objDato._descuento = _descuento;
        objDato._ruta = _ruta;
        objDato._tarjeta = _tarjeta;
        objDato._fechaini = _fechaini + " 00:00:00";
        objDato._fechafin = _fechafin + " 11:59:00";

        ServicioTransportes.ServiceClient sc = new ServicioTransportes.ServiceClient();
        string datos = sc.Consulta(JsonConvert.SerializeObject(objDato));
        var consulta = JsonConvert.DeserializeObject<List<ClsConsulta>>(datos);
        gvConsulta.DataSource = consulta.ToList();
        gvConsulta.DataBind();
    }
}