using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Venta
/// </summary>
public class Venta
{
    public int Idcliente { get; set; }
    public int Idviaje { get; set; }
    public int Cantidad { get; set; }
    public decimal Costo { get; set; }
    public decimal Total { get; set; }
    public DateTime Fechaventa { get; set; }
    public string Asiento { get; set; }
}