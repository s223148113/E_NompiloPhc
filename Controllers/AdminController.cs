using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPhc.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return BadRequest();
            }


            var newRole = new IdentityRole { Name = roleName };
            await _roleManager.CreateAsync(newRole);

            return Ok();
        }

    }
}
