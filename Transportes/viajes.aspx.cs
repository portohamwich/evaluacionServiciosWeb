using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viajes : System.Web.UI.Page
{
    List<Viaje> listaViajes = new List<Viaje>();

    protected void Page_Load(object sender, EventArgs e)
    {
        ServicioTransportes.ServiceClient cliente = new ServicioTransportes.ServiceClient();
        string resultados = cliente.getViajes();
        List<Viaje> lst = JsonConvert.DeserializeObject<List<Viaje>>(resultados);

        List<ViajeView> list = new List<ViajeView>();
        for (int i = 0; i < lst.Count; i++)
        {
            ViajeView vv = new ViajeView();
            vv.Hora = lst[i].Hora;
            vv.Marca = lst[i].camion.marca;
            vv.Modelo = lst[i].camion.modelo;
            vv.Origen = lst[i].ruta.Origen;
            vv.Destino = lst[i].ruta.Destino;
            list.Add(vv);
        }

        listaViajes = lst;
        GridView1.DataSource = list;
        GridView1.DataBind();
    }

    protected async void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (Session["sesIdCliente"] == null)
        {
            Server.Transfer("login.aspx");
        }
        else
        {

            ServicioTransportes.ServiceClient sc = new ServicioTransportes.ServiceClient();
            Viaje v = new Viaje();
            v = listaViajes[GridView1.SelectedRow.RowIndex];

            Venta sale = new Venta();
            sale.Asiento = "1";
            sale.Cantidad = 1;
            sale.Costo = decimal.Parse(v.Costo);
            sale.Idviaje = v.ruta.id;
            sale.Idcliente = int.Parse(Session["sesIdCliente"].ToString());
            sale.Total = sale.Costo * sale.Cantidad;
            string values = JsonConvert.SerializeObject(sale);

            int result = sc.NuevaVenta(values);

            
        }
    }
}