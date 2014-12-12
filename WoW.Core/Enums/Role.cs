using System.ComponentModel.DataAnnotations;

namespace WoW.Core.Enums
{
    public enum Role
    {
        Tank = 1,//start at 1 so default(Role) == 0 doesn't match
        Dps,
        [Display(Name = "Healer")]
        Healing,
    }
}