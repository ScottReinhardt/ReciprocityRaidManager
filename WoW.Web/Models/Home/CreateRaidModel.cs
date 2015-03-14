using System.ComponentModel.DataAnnotations;

namespace WoW.Models.Home
{
    public class CreateRaidModel
    {
        [Display(Name = "Please enter a raid group name")]
        [Required(ErrorMessage = "Group name is required")]
        public string GroupName { get; set; }
        
        [Display(Name = "Please enter server name")]
        [Required(ErrorMessage = "Server name is required")]
        public string ServerName { get; set; }
    }
}