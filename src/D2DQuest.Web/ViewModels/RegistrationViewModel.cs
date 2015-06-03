using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;

namespace D2DQuest.Web.ViewModels
{
    [JsonObject]
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "А как же слово?")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "А это точно слово?")]
        [DisplayName("Волшебное слово")]
        public string Word { get; set; }

        [Required(ErrorMessage = "Необходимо указать свой волшебный номер, он написан на бейдже.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Как то не похоже на волшебный номер. Посмотри на бейдже.")]
        [DisplayName("Твой личный номер")]
        public string UserUid { get; set; }

        public string Message { get; set; }
    }

}