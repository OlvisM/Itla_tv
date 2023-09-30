
using App.Services;
using App.ViewModel;
using DataBase.Contexts;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Itla_Tv_.Controllers
{
    public class SerieController : Controller
    {
        private readonly SerieSevice _services;

        public SerieController(AppContexts Dbcontext)
        {
            _services = new(Dbcontext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _services.GetAllViewModel());
        }

        public IActionResult Crear() 
        {
            return View("GdSerie", new GdSerieViewModel());  
        }
        [HttpPost]
        public async Task<IActionResult> Crear(GdSerieViewModel Gd)
        {
           await _services.Add(Gd);
            return RedirectToRoute(new {controller = "Serie", action="Index" });
        }

        public async Task<IActionResult> Editar(int id)
        {
            return View("Gdserie", await _services.GetByIdGdSerieViewModel(id) );
        }

        [HttpPost]

        public async Task<IActionResult> Editar(GdSerieViewModel Gd)
        {
            await _services.Update(Gd);
            return RedirectToRoute(new { controller = "", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Eliminar", await _services.GetByIdGdSerieViewModel(id));
        }

        [HttpPost]

        public async Task<IActionResult> DeletePost(int id)
        {
            await _services.Delete(id);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }
        
        
    }
}
