using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viajes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ServicioTransportes.ServiceClient cliente = new ServicioTransportes.ServiceClient();
        string resultados = cliente.getViajes();
        List<Viaje> lst = JsonConvert.DeserializeObject<List<Viaje>>(resultados);

        for (int i = 0; i < lst.Count; i++)
        {
            lst[i].Marca = lst[i].camion.marca;
            lst[i].Modelo = lst[i].camion.modelo;
            lst[i].Origen = lst[i].ruta.Origen;
            lst[i].Destino = lst[i].ruta.Destino;
        }

        GridView1.DataSource = lst;
        GridView1.DataBind();
    }
}