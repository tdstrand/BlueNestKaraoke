using BlueNestKaraoke.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlueNestKaraoke.Pages
{
    public class LogInModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogInModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel? Input { get; set; }

        public string? ReturnUrl { get; set; }

        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
        }

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

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid && Input != null && !string.IsNullOrWhiteSpace(Input.PhoneNumber) && !string.IsNullOrWhiteSpace(Input.Password))
            {
                Console.WriteLine($"Attempting login with PhoneNumber: {Input.PhoneNumber}, Password length: {Input.Password.Length}, RememberMe: {Input.RememberMe}");
                var result = await _signInManager.PasswordSignInAsync(Input.PhoneNumber!, Input.Password!, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    Console.WriteLine($"Login succeeded, redirecting to: {ReturnUrl}");
                    return LocalRedirect(ReturnUrl ?? "/");
                }
                else
                {
                    Console.WriteLine($"Login failed: IsLockedOut={result.IsLockedOut}, RequiresTwoFactor={result.RequiresTwoFactor}, IsNotAllowed={result.IsNotAllowed}");
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            else
            {
                Console.WriteLine("ModelState is invalid or Input is null");
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return Page();
        }
    }
}