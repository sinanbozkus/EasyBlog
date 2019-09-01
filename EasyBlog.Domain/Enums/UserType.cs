using System.ComponentModel.DataAnnotations;

namespace EasyBlog.Domain.Enums
{
    public enum UserType
    {
        [Display(Name = "Administrator")]
        Admin = 1,

        [Display(Name = "Guest")]
        Guest = 2
    }
}
