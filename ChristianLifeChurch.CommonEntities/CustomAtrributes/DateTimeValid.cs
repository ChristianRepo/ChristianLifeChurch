using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ChristianLifeChurch.CommonEntities.CustomAtrributes
{
    public class DateTimeValid: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            DateTime dt;

            var ci = new CultureInfo("ru-RU");
            var minYear = DateTime.Now.Year - 3;

            if (!DateTime.TryParse(value.ToString(), ci, DateTimeStyles.None, out dt) || minYear > dt.Year)
            {
                return false;
            }

            return true;
            }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("Поле '{0}' содержит неверную дату", name);
        }
    }
}