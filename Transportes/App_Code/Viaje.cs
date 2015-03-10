using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Viaje
/// </summary>
public class Viaje
{
    

    [JsonProperty("id")]
    public int id { get; set; }

    [JsonProperty("hora")]
    public string Hora { get; set; }

    [JsonProperty("costo")]
    public string Costo { get; set; }

    [JsonProperty("Camion")]
    public Camion camion { get; set; }

    [JsonProperty("Ruta")]
    public Ruta ruta { get; set; }

}

public class ViajeView
{
    public string Origen { get; set; }
    public string Destino { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Hora { get; set; }
}