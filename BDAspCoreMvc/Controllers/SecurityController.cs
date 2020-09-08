using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDData.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BDAspCoreMvc.Controllers
{
    public class SecurityController : Controller
    {
        readonly SignInManager<AppUser> _singInManager;
        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<AppRole> _roleManager;

        public SecurityController(SignInManager<AppUser> singInManager,
                                  UserManager<AppUser> userManager,
                                  RoleManager<AppRole> roleManager)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
            this._singInManager = singInManager;
        }

        public IActionResult Index() { return View(); }

        public IActionResult SingIn() { return View(); }
    }
}
