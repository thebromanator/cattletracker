using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;


namespace CattleTracker.App_Start
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<CattleTracker.Models.ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<CattleTracker.Models.ApplicationUser> store)
            : base(store)
        {
        }

        public static CattleTracker.App_Start.ApplicationUserManager Create(IdentityFactoryOptions<CattleTracker.App_Start.ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new CattleTracker.App_Start.ApplicationUserManager(new UserStore<CattleTracker.Models.ApplicationUser>(context.Get<CattleTracker.Models.ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<CattleTracker.Models.ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<CattleTracker.Models.ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<CattleTracker.Models.ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new CattleTracker.App_Start.EmailService();
            manager.SmsService = new CattleTracker.App_Start.SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<CattleTracker.Models.ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<CattleTracker.Models.ApplicationUser, string>
    {
        public ApplicationSignInManager(CattleTracker.App_Start.ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(CattleTracker.Models.ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((CattleTracker.App_Start.ApplicationUserManager)UserManager);
        }

        public static CattleTracker.App_Start.ApplicationSignInManager Create(IdentityFactoryOptions<CattleTracker.App_Start.ApplicationSignInManager> options, IOwinContext context)
        {
            return new CattleTracker.App_Start.ApplicationSignInManager(context.GetUserManager<CattleTracker.App_Start.ApplicationUserManager>(), context.Authentication);
        }
    }
}
