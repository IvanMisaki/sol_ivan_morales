using SOL_IVAN_MORALES.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOL_IVAN_MORALES.Models.ViewModel
{
    public partial class PrestamoViewModel
    {
        public PRESTAMO PRESTAMO { get; set; }
        public List<LIBRO> lstLibro { get; set; }
        public List<USUARIO> lstUsuario { get; set; }

    }
}