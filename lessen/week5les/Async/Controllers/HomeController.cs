using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Async.Models;

namespace Async.Controllers
{
    public class HomeController : Controller
    {
        public int Counter { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OnGet()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            var run1 = SomeTimeConsumingMethod();
            var run2 = SomeTimeConsumingMethod();
            var run3 = SomeTimeConsumingMethod();

            ViewBag.Messasge1 = run1;
            ViewBag.Messasge2 = run2;
            ViewBag.Messasge3 = run3;

            watch.Stop();
            ViewBag.ElapsedTime = watch.ElapsedMilliseconds;

            return View("Index");
        }

        [HttpGet]
        //asp-action="" kan niet Async lezen. Dus het is eigenlijk OnGetTest!
        public async Task<IActionResult> OnGetTestAsync()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            var run1 = SomeTimeConsumingMethodAsync();
            var run2 = SomeTimeConsumingMethodAsync();
            var run3 = SomeTimeConsumingMethodAsync();

            string s1 = await run1;
            string s2 = await run2;
            string s3 = await run3;

            ViewBag.Messasge1 = s1 + " (" + watch.ElapsedMilliseconds.ToString() + " ms)";
            ViewBag.Messasge2 = s2 + " (" + watch.ElapsedMilliseconds.ToString() + " ms)";
            ViewBag.Messasge3 = s3 + " (" + watch.ElapsedMilliseconds.ToString() + " ms)";

            watch.Stop();
            ViewBag.ElapsedTime = watch.ElapsedMilliseconds;

            return View("Index");
        }

        public string SomeTimeConsumingMethod()
        {
            System.Threading.Thread.Sleep(2000);

            Counter++;

            return "Dit is de boodschap: (" + Counter + " s)";
        }

        public async Task<string> SomeTimeConsumingMethodAsync()
        {
            await Task.Delay(2000);

            Counter++;

            return "Dit is de boodschap: (" + Counter + " s)";
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
