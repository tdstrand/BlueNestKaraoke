using BlueNestKaraoke.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BlueNestKaraoke.Pages
{
    public class LoginModel(SignInManager<ApplicationUser> signInManager) : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

        [BindProperty]
        public InputModel? Input { get; set; }

        public String? ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            public string? PhoneNumber { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string? Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid && Input != null && !string.IsNullOrWhiteSpace(Input.PhoneNumber) && !string.IsNullOrWhiteSpace(Input.Password))
            {
                var result = await _signInManager.PasswordSignInAsync(Input.PhoneNumber!, Input.Password!, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return LocalRedirect(ReturnUrl);
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return Page();
        }
    }
}