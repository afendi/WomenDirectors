using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wbod.Models
{
    public class LoginStatusViewComponent : ViewComponent
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginStatusViewComponent(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //not needed for now as the app requires login: if (_signInManager.IsSignedIn(HttpContext.User))
            //{
                var user = await _userManager.GetUserAsync(HttpContext.User);
                return View("LoggedIn", user);
            //}
            //else
            //{
                //return View();
            //}
        }

    }
}
