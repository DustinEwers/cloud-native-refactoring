using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WiscoIpsum.Models;
using WiscoIpsum.Services;

namespace WiscoIpsum.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIpsumGenerator _generator;
        private readonly IMemoryCache _memoryCache;
        private const string IpsumTextCacheKey = "IpsumText";

        public HomeController(IIpsumGenerator generator, IMemoryCache memoryCache)
        {
            _generator = generator;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            return View(new IpsumViewModel());
        }

        [HttpPost]
        public IActionResult Index(IpsumViewModel model)
        {
            var key = IpsumTextCacheKey + model.Paragraphs;
            if (_memoryCache.TryGetValue(key, out string text)){
                model.IpsumText = text;
            }
            else
            {
                model.IpsumText = _generator.GenerateIpsum(model.Paragraphs);
                _memoryCache.Set(key, model.IpsumText);
            }
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
