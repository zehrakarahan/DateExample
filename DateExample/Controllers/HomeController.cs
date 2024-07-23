using DateExample.Data;
using DateExample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;
using System.Diagnostics;
using System.Xml.Linq;

namespace DateExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public readonly UserManager<IdentityUser> _userManager;
        public readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment,
            UserManager<IdentityUser> userManager,ApplicationDbContext applicationDbContext,
            IConfiguration configuration,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }
      

        public async Task<IActionResult> Index()
        {
            //var contentRoot = _webHostEnvironment.ContentRootPath;
            //string pathToDataFile = contentRoot + "\\Document\\foo.xml";
            //XDocument xdoc = XDocument.Load(pathToDataFile);
            ////Do stuff with XElement and XAttributes...
            //xdoc.Save(pathToDataFile);
            var user = new IdentityUser
            {
                UserName = "zehrakarahan32",
                Email = "zehrakarahan96@gmail.com",
                PhoneNumber = "1"
            };

            var result = await _userManager.CreateAsync(user, "1");
         
            
            return View();
        }

        public IActionResult Privacy()
        {
 
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
