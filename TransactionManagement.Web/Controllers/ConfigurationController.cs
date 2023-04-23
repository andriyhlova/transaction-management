using Microsoft.AspNetCore.Mvc;

namespace TransactionManagement.Web.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly IConfiguration _configuration;

        public ConfigurationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActionResult Index()
        {
            ViewBag.ConnectionString = _configuration.GetConnectionString("AppDbContext");
            ViewBag.Token = _configuration["Token"];
            return View();
        }
    }
}
