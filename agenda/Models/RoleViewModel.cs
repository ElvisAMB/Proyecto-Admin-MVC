﻿using System.ComponentModel.DataAnnotations;

namespace agenda.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Role Name")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}