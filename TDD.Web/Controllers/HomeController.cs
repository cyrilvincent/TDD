using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDD.Services.Library;
using TDD.Services.Library.IoC;
using TDD.Web.Models;

namespace TDD.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new BookViewModels());
        }

        [HttpPost]
        public ActionResult Index(BookViewModels vm)
        {
            IUseCaseService service = UnityHelper.Resolve<IUseCaseService>();
            vm.BookVMs = BookAdapter.Adapt(service.SearchBooks(vm.SearchText));
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}