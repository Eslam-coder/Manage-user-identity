using System.Collections.Generic;

namespace UserMangementWithIdentity.ViewModels
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<RoleView> Roles { get; set; }
    }
}
