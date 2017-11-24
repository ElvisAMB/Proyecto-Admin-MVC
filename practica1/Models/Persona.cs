using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace practica1.Models
{
    public class IPersona
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}