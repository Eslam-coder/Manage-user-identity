using System.ComponentModel.DataAnnotations;

namespace UserMangementWithIdentity.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
