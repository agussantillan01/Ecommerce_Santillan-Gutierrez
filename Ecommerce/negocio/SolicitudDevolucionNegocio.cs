using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class SolicitudDevolucionNegocio
    {
        public void agregarSolicitud(SolicitudDevolucion solicitud)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.setearProcedimiento("SP_InsertaSolicitudDevolucion");

                datos.setearParametro("@IdVenta", solicitud.IdVenta);
                datos.setearParametro("@IdProducto", solicitud.producto.Id);
                datos.setearParametro("@IdColor", solicitud.color.Id);
                datos.setearParametro("@IdUsuario", solicitud.usuario.Id);
                datos.setearParametro("@Motivo", solicitud.motivo);
                datos.setearParametro("@Cantidad", solicitud.cantidad);
               

                datos.ejectutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
