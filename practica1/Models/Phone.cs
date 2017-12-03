using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace practica1.Models
{
  public class Phone
  {
    [Display(Name = "ID")]
    [Key]
    public int PhoneId { get; set; }

    [Required]
    [Display(Name = "Model Name")]
    public string Model { get; set; }

    [Required]
    [Display(Name = "Company Name")]
    public string Company { get; set; }

    [Required]
    [Display(Name = "Price")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    public List<Phone> Seed()
    {
      var phones = new List<Phone>
      {
        new Phone{Model="Samsung Galaxy Note 1", Company="Samsung",Price= 339, PhoneId = 1},
        new Phone{Model="Samsung Galaxy Note 2", Company="Samsung",Price= 399, PhoneId = 2},
        new Phone{Model="Samsung Galaxy S III", Company="Samsung",Price= 217, PhoneId = 3},
        new Phone{Model="Samsung Galaxy S IV", Company="Samsung",Price= 234, PhoneId = 4},
        new Phone{Model="Samsung Galaxy S IV", Company="Samsung",Price= 234, PhoneId = 5},
        new Phone{Model="Samsung Galaxy S V", Company="Samsung",Price= 234, PhoneId = 6},
        new Phone{Model="Samsung Galaxy S VI", Company="Samsung",Price= 400, PhoneId = 7},
        new Phone{Model="Samsung Galaxy S VIII", Company="Samsung",Price= 655, PhoneId = 8},
        new Phone{Model="Samsung Galaxy S VIII Plus", Company="Samsung",Price= 754, PhoneId = 9},
        new Phone{Model="iPhone 5", Company="Apple",Price= 456, PhoneId = 10}
      };

      return phones;
    }
  }
}