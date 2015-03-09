using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsCamion
/// </summary>
public class clsCamion
{

    public int Id { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Categoria { get; set; }
    public int Asientos { get; set; }
    public int Capacidad { get; set; }

	public clsCamion()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}