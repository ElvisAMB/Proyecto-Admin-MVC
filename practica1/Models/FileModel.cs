﻿using System.ComponentModel.DataAnnotations;
using System.Web;

namespace practica1.Models
{
    public class FileModel
    {
        //[Required, FileExtensions(Extensions = "csv",ErrorMessage = "Specify a CSV file. (Comma-separated values)")]
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}