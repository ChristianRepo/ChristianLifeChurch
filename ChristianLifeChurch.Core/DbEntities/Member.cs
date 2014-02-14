using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChristianLifeChurch.CommonEntities;
using ChristianLifeChurch.CommonEntities.CustomAtrributes;
using Newtonsoft.Json;

namespace ChristianLifeChurch.Core.DbEntities
{
    public class Member:Entity
    {
        [JsonProperty]
        [Display(Name = "Имя служителя")]
        [Required(ErrorMessage = LocalConstants.RequiredFieldError)]
        public string FirstName { get; set; }
        [JsonProperty]
        [Display(Name = "Отчество служителя")]
        public string MidleName { get; set; }
        [JsonProperty]
        [Display(Name = "Фамилия служителя")]
        [Required(ErrorMessage = LocalConstants.RequiredFieldError)]
        public string LastName { get; set; }
        [JsonProperty]
        [Display(Name = "Дата рождения служителя")]
        [Required(ErrorMessage = LocalConstants.RequiredFieldError)]
        [DateTimeRusFormat]
        public DateTime DateOfBirth { get; set; }
        [JsonProperty]
        [Display(Name = "Служение в церкви служителя")]
        [Required(ErrorMessage = LocalConstants.RequiredFieldError)]
        public string Job { get; set; }
        [JsonProperty]
        [Display(Name = "Описание служителя")]
        [Required(ErrorMessage = LocalConstants.RequiredFieldError)]
        public string About { get; set; }
        [JsonProperty]
        [Display(Name = "Фото")]
        public string Foto { get; set; }

        [JsonProperty]
        public string FullName {
            get { return string.Format("{0} {1} {2}", LastName, FirstName, MidleName); }
        }
    }
}
