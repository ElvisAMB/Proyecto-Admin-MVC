
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
                            Email = dr["email"].ToString()
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

        public Agenda ConsultarAgendaPersona(Agenda persona)
        {
            Agenda _listado = new Agenda();
            return _listado;
        }
    }
}
