
using App.Services;
using App.ViewModel;
using DataBase.Contexts;
using Itla_Tv_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Itla_Tv_.Controllers
{
    public class HomeController : Controller
    {
        private readonly SerieSevice _seriesService;

        public HomeController(AppContexts dbContrext)
        {
            _seriesService = new(dbContrext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _seriesService.GetAllViewModel());
        }

        public IActionResult Crear() 
        {
            return View("GdSerie", new GdSerieViewModel());
        }
         
    }
}