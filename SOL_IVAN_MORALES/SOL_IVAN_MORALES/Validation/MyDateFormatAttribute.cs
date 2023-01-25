using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SOL_IVAN_MORALES.Validation
{
    public class MyDateFormatAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            var isValid = DateTime.TryParseExact(Convert.ToString(value), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            return (isValid);
        }
    }
}