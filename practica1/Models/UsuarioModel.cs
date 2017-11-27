using practica1.Models;
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
        public long? Id { get; set; }

        [Required(ErrorMessage = "Usuario es requerido")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password es requerido")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Estado { get; set; }
        public string CorreoElectronico { get; set; }
        public string NombresCompletos { get; set; }
        public int Status { get; set; }
        public int Perfil { get; set; }
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
        public List<UsuarioModel> ObtenerUsuarios()
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
                        while (dr.Read())
                        {
                            var usuario = new UsuarioModel
                            {
                                Codigo = long.Parse(dr["UserId"].ToString()),
                                UserName = dr["UserName"].ToString(),
                                Password = dr["Password"].ToString(),
                                CorreoElectronico = dr["Email"].ToString(),
                                Estado = (int.Parse(dr["Status"].ToString()) == 1) ? true : false,
                                NombresCompletos = dr["CompleteName"].ToString()
                            };

                            listadoUsuarios.Add(usuario);
                        }
                    }

                }
            }
            catch (Exception)
            {

            }

            return listadoUsuarios;
        }
        public UsuarioModel ObtenerUsuario(string username, string password)
        {
            UsuarioModel usuario = null;
            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("[SP_UserAccount]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Opcion", 2);
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            usuario = new UsuarioModel
                            {
                                Codigo = long.Parse(dr["UserId"].ToString()),
                                UserName = dr["UserName"].ToString(),
                                Password = dr["Password"].ToString(),
                                CorreoElectronico = dr["Email"].ToString(),
                                Estado = (int.Parse(dr["Status"].ToString()) == 1) ? true : false,
                                NombresCompletos = dr["CompleteName"].ToString(),
                            };
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            return usuario;
        }
    }
}