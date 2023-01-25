using SOL_IVAN_MORALES.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOL_IVAN_MORALES.Models
{
    public partial class PRESTAMO
    {
        [Key]
        public int ID { get; set; }
        public int ID_LIBRO { get; set; }

        public DateTime FECHA_PRESTAMO { get; set; }
        public string DNI_USUARIO { get; set; }
        public int TIPO_LECTURA { get; set; }
        public DateTime? FECHA_DEVOLUCION { get; set; }

    }
}