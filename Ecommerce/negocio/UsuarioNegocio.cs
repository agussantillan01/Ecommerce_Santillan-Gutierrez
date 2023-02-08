using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id,TipoUser from Usuarios Where Email=@Email AND Contraseña=@Contraseña");

                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Contraseña", usuario.Contraseña);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.TipoUsuario = (int)datos.Lector["TipoUser"] == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    return true;
                }
                return false;
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


        //    public void AgregarUsuario(Usuario usuario)
        public int AgregarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_AgregarUsuario");
                datos.setearParametro("@NOMBRE", usuario.Nombre);
                datos.setearParametro("@APELLIDO", usuario.Apellido);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Contraseña", usuario.Contraseña);
                return datos.ejecutarAccionScalar();


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

        public List<Usuario> listarSP(string email = "")
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_listarUsuarios");

                datos.setearParametro("@Email", email);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (Int64)datos.Lector["Id"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Apellido = (string)datos.Lector["APELLIDO"];
                    aux.Contraseña = (string)datos.Lector["Contraseña"];
                    aux.TipoUsuario = (TipoUsuario)datos.Lector["TipoUser"];
                    lista.Add(aux);
                }
                return lista;
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


        public void HacerAdmin(Int64 ID)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                Usuario aux = new Usuario();
                datos.setearProcedimiento("SP_HacerAdmin");
                datos.setearParametro("@Id", ID);

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