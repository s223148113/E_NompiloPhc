using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_NompiloPhc.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
       
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult>Create(ProjectRole role)
        //{
        //    var roleExist = await roleManager.RoleExistsAsync(role.RoleName);
        //    if (roleExist)
        //    {
        //        var result = await roleManager.CreateAsync(new IdentityRole(role.RoleName));

        //    }
        
        //    return View();
        //}
    }
    
}
