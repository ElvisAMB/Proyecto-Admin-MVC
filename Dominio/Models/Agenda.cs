
using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Dominio.Models
{
    public class Agenda : Persona
    {
        private string stringConnection = ConfigurationManager.ConnectionStrings["ConnectionProduccion"].ConnectionString;

        public string Extension { get; set; }
        public string Sucursal { get; set; }
        public string PostBox { get; set; }
        public string Fax { get; set; }
        public string LineaCelular { get; set; }
        public string LineaCelularAdicional { get; set; }

        public List<Agenda> ConsultarAgenda()
        {
            List<Agenda> _listado = new List<Agenda>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("[Agenda].[ConsultarAgenda]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@TipoConsulta", 0);
                    //cmd.Parameters.AddWithValue("@Sucursal", 0);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var persona = new Agenda
                        {
                            FirstName = dr["nombres"].ToString(),
                            LastName = dr["apellidos"].ToString(),
                            Extension = dr["extension"].ToString(),
                            Email = dr["email"].ToString(),
                            Id = int.Parse(dr["id"].ToString())
                        };

                        _listado.Add(persona);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return _listado;
        }

        public Agenda ConsultarAgendaPersona(int id)
        {
            Agenda _agenda = new Agenda();
            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("[Agenda].[ConsultarAgenda]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoConsulta", 1);
                    cmd.Parameters.AddWithValue("@IdAgenda", id);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        _agenda = new Agenda
                        {
                            FirstName = dr["nombres"].ToString(),
                            LastName = dr["apellidos"].ToString(),
                            Extension = dr["extension"].ToString(),
                            Email = dr["email"].ToString()
                        };
                    }
                }
            }
            catch (Exception e)
            {

            }
            return _agenda;
        }

        public bool Guardar()
        {
            bool _respuesta = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("[Agenda].[CrearModificarAgenda]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoOperacion", (Id == 0 ? 0 : 1));
                    cmd.Parameters.AddWithValue("@nombres", FirstName);
                    cmd.Parameters.AddWithValue("@apellidos", LastName);
                    cmd.Parameters.AddWithValue("@extension", Extension);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@sucursal", int.Parse(Sucursal));
                    cmd.Parameters.AddWithValue("@direccion", string.Empty);
                    cmd.Parameters.AddWithValue("@pbx", PostBox);
                    cmd.Parameters.AddWithValue("@fax", Fax);
                    cmd.Parameters.AddWithValue("@lineaCelular", LineaCelular);
                    cmd.Parameters.AddWithValue("@lineaCelularAdicional", LineaCelularAdicional);

                    cmd.ExecuteReader();

                    _respuesta = true;
                }
            }
            catch (Exception e)
            {

            }
            return _respuesta;
        }
    }
}
