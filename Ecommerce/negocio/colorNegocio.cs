using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class colorNegocio
    {
        public List<Color> listarSP(int idProducto)
        {
            List<Color> lista = new List<Color>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ECOMMERCE; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT C.ID, C.NOMBRE FROM COLORES_X_PRODUCTO CXP INNER JOIN COLORES C ON CXP.IDCOLOR=C.ID WHERE CXP.IDPRODUCTO = "+ idProducto;
                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Color color = new Color();
                    color.Id = (int)lector["ID"];
                    if (!(lector["NOMBRE"] is DBNull))
                        color.Nombre = (string)lector["NOMBRE"];


                    lista.Add(color);
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
    }
}
