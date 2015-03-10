using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Transaccion
/// </summary>
public class Transaccion
{
    public int IdVenta { get; set; }
    public string Tarjeta { get; set; }
    public string nombre { get; set; }
    public decimal Cantidad { get; set; }
    public int Codigo { get; set; }
    public DateTime FechaExp { get; set; }
}