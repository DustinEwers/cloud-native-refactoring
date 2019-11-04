using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WiscoIpsum.Models;
using WiscoIpsum.Services;

namespace WiscoIpsum.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIpsumGenerator _generator;

        public HomeController(IIpsumGenerator generator)
        {
            _generator = generator;
        }

        public IActionResult Index()
        {
            return View(new IpsumViewModel());
        }

        [HttpPost]
        public IActionResult Index(IpsumViewModel model)
        {
            model.IpsumText = _generator.GenerateIpsum(model.Paragraphs);
            return View(model);
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
