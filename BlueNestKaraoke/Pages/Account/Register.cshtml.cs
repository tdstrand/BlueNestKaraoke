using BlueNestKaraoke.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BlueNestKaraoke.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private string? returnUrl;

        [BindProperty]
        public InputModel? Input { get; set; }

        public class InputModel
        {
            [Required]
            [Phone]
            public string? PhoneNumber { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string? Password { get; set; }

            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string? ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid && Input != null && !string.IsNullOrWhiteSpace(Input.PhoneNumber) && !string.IsNullOrWhiteSpace(Input.Password))
            {
                var user = new ApplicationUser { UserName = Input.PhoneNumber, PhoneNumber = Input.PhoneNumber };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect("returnUrl");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }
    }
}