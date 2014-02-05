using System;
using System.ComponentModel.DataAnnotations;
using ChristianLifeChurch.CommonEntities;
using ChristianLifeChurch.CommonEntities.CustomAtrributes;
using Newtonsoft.Json;

namespace ChristianLifeChurch.Core.DbEntities
{
    public class Event:Entity{
        [JsonProperty]
        [Display(Name = "Название события")]
        [Required(ErrorMessage = LocalConstants.RequiredFieldError)]
        public string Title { get; set; }
        [JsonProperty]
        [Display(Name = "Описание события")]
        [Required(ErrorMessage = LocalConstants.RequiredFieldError)]
        public string Description { get; set; }

        [Display(Name = "Дата начала события")]
        [JsonProperty]
        [Required(ErrorMessage = LocalConstants.RequiredFieldError)]
        [DataType(DataType.DateTime, ErrorMessage = "Wrong format !!!!")]
        [DateTimeValid]
        public DateTime Start { get; set; }
        [JsonProperty]
        [Display(Name = "Дата окончания события")]
        [DateTimeValid]
        public DateTime? End { get; set; }
    }
}
