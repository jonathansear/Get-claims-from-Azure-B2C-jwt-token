using ExampleClientB2CApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Managers.Interface;
using System.Linq;
using Managers.Modals;

namespace ExampleClientB2CApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITokenManager _tokenManager;

        public HomeController(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public IActionResult Index()
        {
            ClaimProperties UserClaims = _tokenManager.ConvertClaims(User.Identities.FirstOrDefault().Claims);

            string name = UserClaims.name;

            string jobTitle = UserClaims.jobTitle;

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
