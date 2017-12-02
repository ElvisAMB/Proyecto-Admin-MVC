using System.Collections.Generic;

namespace Dominio.Models
{
    public class Cliente
    {
        public string ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> _listadoClientes = new List<Cliente> {
             new Cliente { ClienteId = "1", Nombre = "Julio Avellaneda", Correo = "julito_gtu@hotmail.com"},
             new Cliente { ClienteId = "2", Nombre = "Juan Torres", Correo = "jtorres@hotmail.com"},
             new Cliente { ClienteId = "3", Nombre = "Oscar Camacho", Correo = "oscarca@hotmail.com"},
             new Cliente { ClienteId = "4", Nombre = "Gina Urrego", Correo = "ginna@hotmail.com"},
             new Cliente { ClienteId = "5", Nombre = "Nathalia Ramirez", Correo = "natha@hotmail.com"},
             new Cliente { ClienteId = "6", Nombre = "Raul Rodriguez", Correo = "rodriguez.raul@hotmail.com"},
             new Cliente { ClienteId = "7", Nombre = "Johana Espitia", Correo = "johana_espitia@hotmail.com"},
             new Cliente { ClienteId = "8", Nombre = "Elvis Alfredo Mora Barros", Correo = "elvis.mora@confianza.com.ec"},
             new Cliente { ClienteId = "9", Nombre = "Bruce Avellaneda", Correo = "batman@hotmail.com"},
             new Cliente { ClienteId = "10", Nombre = "Clark Torres", Correo = "superman@hotmail.com"},
             new Cliente { ClienteId = "11", Nombre = "Diana Camacho", Correo = "wondderwoman@hotmail.com"},
             new Cliente { ClienteId = "12", Nombre = "Barry Urrego", Correo = "flash@hotmail.com"},
             new Cliente { ClienteId = "13", Nombre = "Arthur Ramirez", Correo = "aquaman@hotmail.com"},
             new Cliente { ClienteId = "14", Nombre = "Victor Rodriguez", Correo = "cyborg@hotmail.com"},
             new Cliente { ClienteId = "15", Nombre = "Hal Espitia", Correo = "linternaverde@hotmail.com"},
             };

            return _listadoClientes;
        }

    }
}
