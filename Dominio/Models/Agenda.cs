
using Dominio.Models;
using System.Collections.Generic;

namespace Dominio.Models
{
    public class Agenda : Persona
    {
        public string Extension { get; set; }
        public string Sucursal { get; set; }
        public string PostBox { get; set; }
        public string Fax { get; set; }
        public string LineaCelular { get; set; }
        public string LineaCelularAdicional { get; set; }

        public List<Agenda> ConsultarAgenda()
        {
            List<Agenda> _listado = new List<Agenda>();
            return _listado;
        }

        public Agenda ConsultarAgendaPersona(Agenda persona)
        {
            Agenda _listado = new Agenda();
            return _listado;
        }
    }
}
