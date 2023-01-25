using SOL_IVAN_MORALES.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOL_IVAN_MORALES.Models
{
    public partial class LIBRO
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string CATEGORIA { get; set; }
        public string AUTOR { get; set; }
        public string PAIS { get; set; }
        public string FECHA_PUBLICACION { get; set; }
        public string EDITORIAL { get; set; }
    }
}