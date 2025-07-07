using CRUD.Models.Entites;
using CRUD.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CRUD.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
 

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
  
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (model == null)
                return BadRequest("Login data is missing.");

            if (!ModelState.IsValid)
                return BadRequest("Invalid login request.");

            var result = await _signInManager.PasswordSignInAsync(model.Email!, model.Password!, isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                //generate jwt token
               // var token = await _authService.GenerateTokenAsync(model.Email);

                // sending mail that you have logged in
                //var body = $"You have logged in  successfully if not you report changes done";
                //var subject = $"Login Successfull";
                //await _emailService.SendEmailAsync(model.Email!,subject,body);

                return RedirectToAction("Index","Employe");
            }

            return Unauthorized("Invalid credentials.");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string role = "User")
        {
            if (model == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            User user = new User()
            {
                UserName = model.Email,
                NormalizedUserName = model.First_Name.ToUpper() + model.Last_Name.ToUpper(),
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D").ToUpper(),
                FirstName = model.First_Name,
                LastName = model.Last_Name,
                DateRegistered = DateTime.UtcNow,
                PhoneNumber = model.phonenumber
            };
            var result = await _userManager.CreateAsync(user, model.Password!);
            if (result.Succeeded)
            {
                var roleresult = await _userManager.AddToRoleAsync(user, role);
                if (roleresult.Succeeded)
                {
                    // send registration successfull email
                    var body = $" Dear {model.First_Name} you have successfully registred";
                    var subject = $"Registration Successfull";
                    var receptor = model.Email;

                    //  await _emailService.SendEmailAsync(receptor, subject, body);

                    RedirectToAction("Account,Login");
                }
                else
                {
                    ModelState.AddModelError(",","error occurred while adding role to account");
                    RedirectToAction("Account,Register");
                }

            }
            else
            {
                ModelState.AddModelError(",", "unable to create user");
                RedirectToAction("Account,Register");
            }
            return RedirectToAction("Account","Register");
        }

        [HttpGet]
        public IActionResult VerifyEmail()
        {
            return View();
        }


        [HttpPost("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            if (model == null)
                return BadRequest("Login data is missing.");

            if (!ModelState.IsValid)
                return BadRequest("Invalid login request.");

            var user = await _userManager.FindByEmailAsync(model.Email!);

            if (user != null)
            {
                // send verification email that should redirect to change password
                var body = $"https://yourfrontend.com/reset-password?token={"token"}&email={user.Email}";
                var subject = $"Registration Successfull";
                var receptor = model.Email;

                //  await _emailService.SendEmailAsync(receptor!, subject, body);

                RedirectToAction("Account,ChangePassword");
            }
            else
            {
                ModelState.AddModelError(",", "user not found");
                RedirectToAction("Account,VerifyEmail");
            }
            return RedirectToAction("Account","VerifyEmail");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (model == null)
                return BadRequest("Password data is missing.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.New_Password != model.Confirm_New_Password)
                return BadRequest("New password and confirmation do not match.");

            var user = await _userManager.FindByEmailAsync(model.Email!);
            if (user == null)
            {
                ModelState.AddModelError(",", "user not found");
                RedirectToAction("Account,Register");
            }
            // Change the password securely
            var result = await _userManager.ChangePasswordAsync(user, model.Current_Password!, model.New_Password!);

            if (result.Succeeded)
            {
                // send email for changing password
                var body = $"Your password has been changed , report if not you";
                var subject = $"Password Changed";
                var receptor = model.Email;
                //    await _emailService.SendEmailAsync(receptor!, subject, body);


                RedirectToAction("Account,Login");
            }

          return  RedirectToAction("Account,Login");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");

        }

    }
}
