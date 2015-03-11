using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
    #region Rutas
    [OperationContract]
	string getRoutes();

    [OperationContract]
    string getRoute(int id);
    #endregion

    #region Viajes
    [OperationContract]
    string getViajes();

    [OperationContract]
    string getViaje(int id);
    #endregion

    #region Clientes
    [OperationContract]
    string getAllClientes();

    [OperationContract]
    DataTable getCliente(string dato);

    [OperationContract]
    bool insertCliente(string datos);

    [OperationContract]
    bool updateCliente(string datos);

    [OperationContract]
    bool exist(string datos);
    #endregion


    [OperationContract]
    DataTable session(string datos);

    #region Ventas
    [OperationContract]
    string SeleccionaVentas();

    [OperationContract]
    int NuevaVenta(string objeto);
    #endregion 

    #region PAGO
    [OperationContract]
    DataTable pago(string datos);
    #endregion  

    #region DESCUENTOS
    [OperationContract]
    string getDescuentos();
    #endregion

    #region CONSULTA
    [OperationContract]
    string Consulta(string datos);
    #endregion

    #region CATEGORIAS
    [OperationContract]
    string getCategorias();
    #endregion

}
