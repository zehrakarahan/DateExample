using DateExample.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace DateExample
{
    public class PasswordPolicyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        public PasswordPolicyService(ApplicationDbContext context, IConfiguration configuration,


            IServiceProvider serviceProvider)
        {
            _context = context;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        public PasswordPolicy GetPasswordPolicy()
        {
            try
            {
                // Veritabanından şifre politikası ayarlarını al
                var policy = _context.PasswordPolicies.FirstOrDefault();

                if (policy == null)
                {
                    // Varsayılan şifre politikası ayarlarını döndür (isteğe bağlı)
                    return new PasswordPolicy
                    {
                        RequireDigit = false,
                        RequireLowercase = false,
                        RequireUppercase = false,
                        RequireNonAlphanumeric = false,
                        RequiredLength = 6
                    };
                }

                return policy;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public PasswordOptions GetPasswordOptionsZehra()
        {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var builder = scope.ServiceProvider.GetRequiredService<IWebHostBuilder>();

                    var data = dbContext.PasswordPolicies.ToList();
                PasswordOptions passwordOptions = new PasswordOptions();
                passwordOptions.RequireDigit = data.FirstOrDefault()!.RequireDigit;
                passwordOptions.RequireNonAlphanumeric= data.FirstOrDefault()!.RequireNonAlphanumeric;
                passwordOptions.RequireLowercase= data.FirstOrDefault()!.RequireLowercase;
                passwordOptions.RequireUppercase= data.FirstOrDefault()!.RequireUppercase;
                passwordOptions.RequiredLength = data.FirstOrDefault()!.RequiredLength;
                passwordOptions.RequiredUniqueChars = 1;
                return passwordOptions;
            }
            return null;
        }
    }
}
