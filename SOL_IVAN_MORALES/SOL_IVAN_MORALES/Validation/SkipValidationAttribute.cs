using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOL_IVAN_MORALES.Validation
{
    public class SkipValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return true;
        }
    }
}