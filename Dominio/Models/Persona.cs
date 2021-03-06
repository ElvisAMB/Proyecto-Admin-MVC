﻿using System;

namespace Dominio.Models
{
  public class Persona
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MidleName { get; set; }
    public string LastName { get; set; }
    public string SecondLastName { get; set; }
    public string Code { get; set; }
    public string Email { get; set; }
    public DateTime AdmissionDate { get; set; }
    public string Address { get; set; }
    public string _completeNames;

    public string CompleteNames
    {
      get { return FirstName + " " + LastName; }
    }
  }
}