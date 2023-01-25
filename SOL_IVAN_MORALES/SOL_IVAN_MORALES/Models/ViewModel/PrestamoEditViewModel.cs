using SOL_IVAN_MORALES.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOL_IVAN_MORALES.Models.ViewModel
{
    public partial class PrestamoEditViewModel
    {
        public PRESTAMO PRESTAMO { get; set; }
        public LIBRO libro { get; set; }
        public USUARIO usuario { get; set; }
        public bool devuelto { get; set; }

    }
}