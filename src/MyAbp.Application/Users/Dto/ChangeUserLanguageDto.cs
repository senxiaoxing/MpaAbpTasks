using System.ComponentModel.DataAnnotations;

namespace MyAbp.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}