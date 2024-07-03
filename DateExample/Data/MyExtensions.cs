using Microsoft.AspNetCore.Identity;

namespace DateExample.Data
{
    public static class MyExtensions
    {
      
        public static WebApplicationBuilder ConfigureIdentityPasswordOptions(this WebApplicationBuilder builder)
        {
            var serviceProvider = builder.Services.BuildServiceProvider();

            // Örneğin, UserManager veya benzeri bir servis kullanabilirsiniz
            var userManager = serviceProvider.GetRequiredService<MyService>();

            var passwordManager = userManager.GetPasswordOptionsZehra();
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = passwordManager.RequireDigit;
                options.Password.RequiredLength = passwordManager.RequiredLength;
                options.Password.RequireNonAlphanumeric = passwordManager.RequireNonAlphanumeric;
                options.Password.RequireUppercase = passwordManager.RequireUppercase;
                options.Password.RequireLowercase = passwordManager.RequireLowercase;
                options.Password.RequiredUniqueChars = passwordManager.RequiredUniqueChars;
            });

            return builder;
        }
    }
}
