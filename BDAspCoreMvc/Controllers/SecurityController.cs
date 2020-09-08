using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDData.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

        public IActionResult SignIn() {
            var model = new SignIn();
            return View(model); 
        }

        [HttpPost]
        public IActionResult SignIn(SignIn model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction("Index", "Employees");
            throw new NotImplementedException("Sign in is not implemented yet");
        }

        public IActionResult SignUp()
        {
            var model = new Register();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(Register model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var existingUser = await _userManager.FindByNameAsync(model.UserName);
            if (existingUser != null)
            {
                ModelState.AddModelError("existingUser", "Username is already taken");
                return View(model);
            }
            var userResult = await _userManager.CreateAsync(new AppUser { 
            UserName = model.UserName,
            Email = model.UserName}, model.Password);

            if (!userResult.Succeeded)
            {
                ModelState.AddModelError("", "user could not be created");
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            await _userManager.AddToRoleAsync(user, "free");
            await _singInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Employees");
            
        }
    }
}
