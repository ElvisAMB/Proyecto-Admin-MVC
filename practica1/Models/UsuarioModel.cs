using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace practica1.Models
{
    public class UsuarioModel : Respuesta
    {
        private string stringConnection = ConfigurationManager.ConnectionStrings["ConnectionProduccion"].ConnectionString;

        [Required(ErrorMessage = "Usuario es requirido")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password es requirida")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool Estado { get; set; }
        public string CorreoElectronico { get; set; }

        public Respuesta Verificar(UsuarioModel usuario)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("[SP_UserAccount]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Opcion", 0);
                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Decimal, 10)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@mensaje", SqlDbType.VarChar, 10)).Direction = ParameterDirection.Output;
                    //SqlDataReader dr = cmd.ExecuteReader();

                    cmd.ExecuteReader();

                    var codigo = long.Parse(cmd.Parameters["@codigo"].Value.ToString());
                    var mensaje = cmd.Parameters["@mensaje"].Value.ToString();

                    respuesta = new Respuesta
                    {
                        Codigo = codigo,
                        Mensaje = mensaje
                    };
                }
            }
            catch (Exception e)
            {
                respuesta = new Respuesta
                {
                    Codigo = 9999,
                    Mensaje = e.Message
                };
            }

            return respuesta;
        }

        public List<UsuarioModel> ObtenerUsuario()
        {
            List<UsuarioModel> listadoUsuarios = null;

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("[SP_UserAccount]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Opcion", 1);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        listadoUsuarios = new List<UsuarioModel>();
                        while (dr.HasRows)
                        {

                        }
                    }
                    
                }
            }
            catch (Exception e)
            {

            }

            return listadoUsuarios;
        }

    }
}