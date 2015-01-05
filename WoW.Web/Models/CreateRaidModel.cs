using System.ComponentModel.DataAnnotations;

namespace WoW.Models
{
    public class CreateRaidModel
    {
        [Display(Name = "Please enter a raid group name")]
        [Required(ErrorMessage = "Group Name is required")]
        public string GroupName { get; set; }
    }
}