// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SellWise.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static SellWise.Extensions.CustomClaims;

namespace SellWise.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Cashier> signInManager;
        private readonly UserManager<Cashier> userManager;
        private readonly IUserStore<Cashier> userStore;
        private readonly ILogger<RegisterModel> logger;

        public RegisterModel(
            UserManager<Cashier> userManager,
            IUserStore<Cashier> userStore,
            SignInManager<Cashier> signInManager,
            ILogger<RegisterModel> logger)
        {
            this.userManager = userManager;
            this.userStore = userStore;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [StringLength(100, MinimumLength = 2, ErrorMessage = "Cashier First Name Must Be Between 2 and 100 Characters Long.")]
            public string FirstName { get; set; } = null!;

            [Required]
            [StringLength(100, MinimumLength = 2, ErrorMessage = "Cashier Last Name Must Be Between 2 and 100 Characters Long.")]
            public string LastName { get; set; } = null!;
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                Cashier user = CreateUser();

                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;

                await userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);

                IdentityResult result = await userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim(UserFirstNameClaim, $"{user.FirstName}"));

                    if (user.EmailConfirmed == false)
                    {
                        //To Implement Function for the user to wait while his account is confirmed
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

        private Cashier CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Cashier>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Cashier)}'. " +
                    $"Ensure that '{nameof(Cashier)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
        private IUserEmailStore<Cashier> GetEmailStore()
        {
            if (!userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }

            return (IUserEmailStore<Cashier>)userStore;
        }
    }
}
