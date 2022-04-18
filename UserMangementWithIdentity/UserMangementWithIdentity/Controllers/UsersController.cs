using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UserMangementWithIdentity.Models;
using UserMangementWithIdentity.ViewModels;

namespace UserMangementWithIdentity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.Select(user => new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Roles = _userManager.GetRolesAsync(user).Result
            }).ToListAsync();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();
            var roles = _roleManager.Roles.ToListAsync();
            var viewModel = new UserRoleViewModel
            {
                UserId = userId,
                UserName = user.UserName,
                Roles = roles.Select(roles => new RoleView
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, role.Name)
                }).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ManageRoles(UserRoleViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound();

            //هنا بجيب كل الادوار اللى واخدها مستخدم ده
            var userRoles = await _userManager.GetRolesAsync(user);

            //هنا بجيب كل الادوار اللى موجوده ف داتا بيز 
            var roles = _roleManager.Roles.ToListAsync();

            foreach (var role in model.Roles)
            {
                if(userRoles.Any(r=>r == role.RoleName) && !role.IsSelected)
                {
                    await _userManager.RemoveFromRoleAsync(user,role.RoleName);
                }
                if (!userRoles.Any(r => r == role.RoleName) && role.IsSelected)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserViewModel model)
        {
            //هنا بجيب كل الادوار اللى موجوده ف داتا بيز 
            var roles = _roleManager.Roles.Select(r => new RoleView {RoleId = r.Id , RoleName = r.Name}).ToListAsync();

            var viewModel = new UserViewModel
            {
                Roles = roles
            };
            return View(viewModel);
        }
    }
}
