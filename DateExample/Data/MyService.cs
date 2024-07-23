using Microsoft.AspNetCore.Identity;

namespace DateExample.Data
{
    public class MyService
    {
        private readonly IServiceProvider _serviceProvider;

        public MyService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        //public void FetchData()
        //{
        //    using (var scope = _serviceProvider.CreateScope())
        //    {
        //        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        //        var builder = scope.ServiceProvider.GetRequiredService<IWebHostBuilder>();

        //        var data = dbContext.PasswordPolicies.ToList();
        //        foreach (var item in data)
        //        {
                
        //            Console.WriteLine($"ID: {item.Id}, Name: {item.RequireLowercase}");
        //        }
        //    }
        //}
        public PasswordOptions GetPasswordOptionsZehra()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                //var builder = scope.ServiceProvider.GetRequiredService<IWebHostBuilder>();

                var data = dbContext.PasswordPolicies.ToList();
                PasswordOptions passwordOptions = new PasswordOptions();
                passwordOptions.RequireDigit = data.FirstOrDefault()!.RequireDigit;
                passwordOptions.RequireNonAlphanumeric = data.FirstOrDefault()!.RequireNonAlphanumeric;
                passwordOptions.RequireLowercase = data.FirstOrDefault()!.RequireLowercase;
                passwordOptions.RequireUppercase = data.FirstOrDefault()!.RequireUppercase;
                passwordOptions.RequiredLength = data.FirstOrDefault()!.RequiredLength;
                passwordOptions.RequiredUniqueChars = 1;
                return passwordOptions;
            }
            return null;
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
}
