using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristianLifeChurch.CommonEntities.CustomAtrributes
{
    public class DateTimeRusFormat:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt;

            var ci = new CultureInfo("ru-RU");

            if (!DateTime.TryParse(value.ToString(), ci, DateTimeStyles.None, out dt))
            {
                return false;
            }

            return true;
        }
    }
}
