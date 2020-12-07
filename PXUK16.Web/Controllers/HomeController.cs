using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PXUK16.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PXUK16.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Manufactory> manufactories = new List<Manufactory>();
            manufactories = Helper.ApiHelper<List<Manufactory>>.HttpGetAsync("api/manafactory/gets");
            return View(manufactories);
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateManafactory model)
        {
            if (ModelState.IsValid)
            {
                var result = new CreateManafactoryResult();
                result = Helper.ApiHelper<CreateManafactoryResult>.HttpPostAsync("api/manafactory/create", "POST", model);
                if (result.ManufactoryId > 0)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", result.Message);
                return View(model);
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(UpdateManafactory model)
        {
            if (ModelState.IsValid)
            {
                var result = new UpdateManafactoryResult();
                result = Helper.ApiHelper<UpdateManafactoryResult>.HttpPostAsync("api/Manufactory/update", "POST", model);
                if (result.ManufactoryId > 0)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", result.Message);
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(DeleteManafactory model)
        {
            if (ModelState.IsValid)
            {
                var result = new DeleteManafactoryResult();
                result = Helper.ApiHelper<DeleteManafactoryResult>.HttpPostAsync("api/Manufactory/Delete", "POST", model);
                if (result.ManufactoryId > 0)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", result.Message);
                return View(model);
            }
            return View(model);
        }
    }
}
