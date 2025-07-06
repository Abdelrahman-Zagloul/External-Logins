using External_Logins.Data;
using External_Logins.Models;
using External_Logins.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace External_Logins
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //add db context
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection")));

            // Add Identity services
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                  .AddDefaultTokenProviders();

            // DI for EmailSender
            builder.Services.AddTransient<IEmailSender, EmailSender>();


            #region Configure authentication with External Logins

            // Configure authentication with External Logins
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                //options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogle(options =>
            {
                options.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? "";
                options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? ""; ;
            })
            .AddGitHub(options =>
            {
                options.ClientId = builder.Configuration["Authentication:GitHub:ClientId"] ?? "";
                options.ClientSecret = builder.Configuration["Authentication:GitHub:ClientSecret"] ?? "";
                options.Scope.Add("user:email");
            })
            .AddFacebook(options =>
            {

                options.ClientId = builder.Configuration["Authentication:Facebook:AppId"] ?? "";
                options.ClientSecret = builder.Configuration["Authentication:Facebook:AppSecret"] ?? "";
                options.Fields.Add("name");
                //options.Fields.Add("email");
                //options.Scope.Add("email");
            })
            .AddLinkedIn(options=>
            {
                options.ClientId= builder.Configuration["Authentication:LinkedIn:ClientId"] ?? "";
                options.ClientSecret = builder.Configuration["Authentication:LinkedIn:ClientSecret"] ?? "";
                options.Scope.Add("openid"); 
                options.Scope.Add("profile"); 
                options.Scope.Add("email");   
            })
            .AddMicrosoftAccount(options =>
            {
                options.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"] ?? "";
                options.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"] ?? "";
                options.SaveTokens = true;
                options.Scope.Clear();
                options.Scope.Add("openid");
                options.Scope.Add("email");
                options.Scope.Add("profile");
                options.Scope.Add("User.Read");
            })
            ;
            #endregion






            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
