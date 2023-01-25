using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOL_IVAN_MORALES.Models
{
    public partial class USUARIO
    {
        [Key]
        public string DNI { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONO { get; set; }
        public int ESTADO { get; set; }
        public int TIPO { get; set; }
    }
}