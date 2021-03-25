using BackGround;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using System.Text;
using Ziekenhuis.Asynchronous;
using Ziekenhuis.Models;
//using BackGround; 

namespace Ziekenhuis.Ziekenhuis.Controllers
{
    public class HomeController : Controller
    {
              
        public IActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Index(IFormFile file)
        {
            var result = new StringBuilder();

            if (file != null && file.Length > 0)
            {
                using (TextReader reader = new StreamReader(file.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                        result.AppendLine(reader.ReadLine());
                }
            }

            var text = result.ToString();

            return View();
        }




        public IActionResult StartBackGround()
        {
            var asyncProcesses = new ASyncProcesses();
            asyncProcesses.CallBackGround();
            return RedirectToAction("Index");
             
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
