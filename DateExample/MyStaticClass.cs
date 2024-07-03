using DateExample.Data;
using Microsoft.AspNetCore.Identity;
using static System.Formats.Asn1.AsnWriter;

namespace DateExample
{
    public static class MyStaticClass
    {
        public static void MyStaticMethod(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var myService = serviceProvider.GetRequiredService<MyService>();

                // Veritabanından gerekli verileri almak için dbContext kullanabiliriz
                var data = myService.GetPasswordOptionsZehra();
                var dataDb = dbContext.PasswordPolicies.ToList();
                PasswordOptions passwordOptions = new PasswordOptions();
                passwordOptions.RequireDigit = dataDb.FirstOrDefault()!.RequireDigit;
                passwordOptions.RequireNonAlphanumeric = dataDb.FirstOrDefault()!.RequireNonAlphanumeric;
                passwordOptions.RequireLowercase = dataDb.FirstOrDefault()!.RequireLowercase;
                passwordOptions.RequireUppercase = dataDb.FirstOrDefault()!.RequireUppercase;
                passwordOptions.RequiredLength = dataDb.FirstOrDefault()!.RequiredLength;
                passwordOptions.RequiredUniqueChars = 1;
            }
        }
    }

    //public static void ConfigurePasswordOptions(IWebHostBuilder builder)
    //{
    //    builder.ConfigureServices(services =>
    //    {
    //        using (var scope = services.BuildServiceProvider().CreateScope())
    //        {
    //            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    //            var passwordPolicyService = scope.ServiceProvider.GetRequiredService<PasswordPolicyService>();
    //            var passwordOptions = passwordPolicyService.GetPasswordPolicy();

    //            services.Configure<IdentityOptions>(options =>
    //            {
    //                options.Password.RequireDigit = passwordOptions.RequireDigit;
    //                options.Password.RequireLowercase = passwordOptions.RequireLowercase;
    //                options.Password.RequireNonAlphanumeric = passwordOptions.RequireNonAlphanumeric;
    //                options.Password.RequireUppercase = passwordOptions.RequireUppercase;
    //                options.Password.RequiredLength = passwordOptions.RequiredLength;
    //                // Diğer şifre seçeneklerini buraya ekleyebilirsiniz
    //            });
    //        }
    //    });
    //}
}
