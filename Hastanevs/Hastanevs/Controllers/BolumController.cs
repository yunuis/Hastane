using Hastanevs.Models;
using Hastanevs.Utility;
using Microsoft.AspNetCore.Mvc;

namespace Hastanevs.Controllers
{
    public class BolumController : Controller
    {
        //dependency injection özelliği sayesinde new anahtarı ile yeni nesne türetmeden containerdaki nesneyi enjekte etmiş oluyoruz.
        //program.cs dosyasındaki service kısmına yazdığımız kodlar bunu sağladı.
        private readonly HastaneDbContext _hastaneDbContext;

        public BolumController(HastaneDbContext context)
        {
            _hastaneDbContext = context;
        }
        public IActionResult Index()
        {
            List<Bolum> objBolumList = _hastaneDbContext.Bolumler.ToList();
            return View(objBolumList);
        }
        public IActionResult Goz()
        {
            return View();
        }
        public IActionResult Cildiye()
        {
            return View();
        }
        public IActionResult Noroloji()
        {
            return View();
        }
    }
}
