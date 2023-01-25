using SOL_IVAN_MORALES.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOL_IVAN_MORALES.Models
{
    public partial class PRESTAMO_DETALLE
    {
        public PRESTAMO PRESTAMO { get; set; }
        public LIBRO LIBRO { get; set; }
        public USUARIO USUARIO { get; set; }

    }
}