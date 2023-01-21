using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CompraNegocio
    {
        public void registroCompra( carritoCompra carrito)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_AgregarCompra");
                datos.setearParametro("@Id", carrito.Id);
                datos.setearParametro("@IdUsuario", 1);
                //datos.setearParametro("@FechaCompra", carrito.FechaCompra);
                datos.setearParametro("@Total", carrito.total);

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

        public List<carritoCompra>  listar()
        {


            List<carritoCompra> lista = new List<carritoCompra>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT ID, IDUSUARIO, PRECIOTOTAL FROM VENTAS";



                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    carritoCompra carrito = new carritoCompra();
                    carrito.Id = (int)lector["ID"];
                    if (!(lector["IDUSUARIO"] is DBNull))
                        carrito.IdUsuario = (int)lector["IDUSUARIO"];
                    if (!(lector["PRECIOTOTAL"] is DBNull))
                        carrito.total = (decimal)lector["PRECIOTOTAL"];


                    lista.Add(carrito);
                }


                    return lista;


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void agregarDetalleXventa(itemCarrito item, int id)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_agregarDetalleVenta");
                datos.setearParametro("@Id", id);
                datos.setearParametro("@IdProducto", item.id);
                datos.setearParametro("@IdColor", item.color.Id);
                datos.setearParametro("@Cantidad", item.cantidad);
                datos.setearParametro("@Precio", item.subtotal);

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
