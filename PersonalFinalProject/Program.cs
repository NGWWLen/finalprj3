using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalFinalProject.Data;

namespace PersonalFinalProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false) //So we can log in ??
                //Add here for identity role
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            //Add here
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = 
                    scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Admin", "Manager", "Employee", "Member" };

                foreach (var role in roles)
                {
                    if(! await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }

            //Add Admin
            using (var scope = app.Services.CreateScope())
            {
                var userManager =
                    scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string adminEmail = "admin@admin.com";
                string adminPassword = "P@ssw0rd";

                //If account with adminEmail not found
                if(await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    //Create user
                    var user = new IdentityUser();
                    user.UserName = adminEmail;
                    user.Email = adminEmail;

                    //Create the user + add password
                    await userManager.CreateAsync(user, adminPassword);

                    //Add the user to admin role
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            app.Run();
        }
    }
}