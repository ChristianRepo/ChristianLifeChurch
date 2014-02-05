using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ChristianLifeChurch.CommonEntities.CustomAtrributes;

namespace ChristianLifeChurch.CommonEntities
{
    public class Event
    {
        public int Id { get; set; }

        [Display(Name = "Название события")]
        [Required(ErrorMessage = LocalConstants.RequiredFieldError)]
        public string Title { get; set; }
        [Display(Name = "Описание события")]
        [Required(ErrorMessage = LocalConstants.RequiredFieldError)]
        public string Description { get; set; }

        [Display(Name = "Дата начала события")]
        [Required(ErrorMessage = LocalConstants.RequiredFieldError)]
        [DataType(DataType.DateTime, ErrorMessage = "Wrong format !!!!")]
        [DateTimeValid]
        public DateTime Start { get; set; }
        [Display(Name = "Дата окончания события")]
        [DateTimeValid]
        public DateTime? End { get; set; }
    }
}
