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

        public IActionResult SingIn() {
            var model = new SignIn();
            return View(model); 
        }

        [HttpPost]
        public IActionResult SignIn(SignIn model)
        {
            throw new NotImplementedException("Sign in is not implemented yet");
        }

        public IActionResult SignUp()
        {
            var model = new Register();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignUp(Register model)
        {
            throw new NotImplementedException();
        }
    }
}
