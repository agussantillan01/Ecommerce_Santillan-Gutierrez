using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class productoNegocio
    {
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT P.ID,P.NOMBRE,P.DESCRIPCION,M.ID AS IDMARCA ,M.NOMBRE AS MARCA,T.ID AS IDTIPO,T.NOMBRE AS TIPO, P.IMAGEN,P.PRECIO FROM PRODUCTOS P INNER JOIN MARCAS M ON M.ID=P.IDMARCA INNER JOIN TIPOS T ON T.ID=P.IDTIPO ";
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (int)lector["ID"];
                    if (!(lector["NOMBRE"] is DBNull))
                        prod.Nombre = (string)lector["NOMBRE"];
                    if (!(lector["DESCRIPCION"] is DBNull))
                        prod.Descripcion = (string)lector["DESCRIPCION"];
                    if (!(lector["IMAGEN"] is DBNull))
                        prod.Imagen = (string)lector["IMAGEN"];
                    if (!(lector["PRECIO"] is DBNull))
                        prod.Precio = (decimal)lector["PRECIO"];

                    prod.Marca = new Marca();
                    prod.Marca.Id = (int)lector["IDMARCA"];
                    prod.Marca.Nombre = (string)lector["MARCA"];


                    prod.Tipo = new Tipo();
                    prod.Tipo.Id = (int)lector["IDTIPO"];
                    //SI EL TIPO DE ARTICULO NO ES NULO LO LEE
                    if (!(lector["TIPO"] is DBNull))
                        prod.Tipo.Nombre = (string)lector["TIPO"];



                    lista.Add(prod);
                }

                //conexion.Close();
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

        public void agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_AGREGARPRODUCTO");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Tipo", nuevo.Tipo.Id);
                datos.setearParametro("@Marca", nuevo.Marca.Id);
                datos.setearParametro("@Imagen", nuevo.Imagen);
                datos.setearParametro("@Precio", nuevo.Precio);

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
