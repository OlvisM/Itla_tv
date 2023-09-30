using App.Repository;
using App.ViewModel;
using DataBase.Contexts;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class SerieSevice
    {
        private readonly SeriesRepository _serieRepository;

        public SerieSevice(AppContexts dbcontext)
        {
            _serieRepository = new(dbcontext);
        }
        public async Task Add(GdSerieViewModel Gd)
        {
            Series series = new();

            series.Name = Gd.Name;
            series.Description = Gd.Description;
            series.Imagen = Gd.Imagen;
            series.Trailer = Gd.Trailer;
            series.Genero = Gd.Genero;
            series.CategoryId = Gd.CategoryId;
            series.Productora = Gd.Productora;

            await _serieRepository.AddAsync(series);
        }
        public async Task Update(GdSerieViewModel Gd)
        {
            Series series = new();

            series.Id = Gd.Id;
            series.Name = Gd.Name;
            series.Description = Gd.Description;
            series.Imagen = Gd.Imagen;
            series.Trailer = Gd.Trailer;
            series.Genero = Gd.Genero;
            series.CategoryId = Gd.CategoryId;
            series.Productora = Gd.Productora;

            await _serieRepository.UdapteAsync(series);
        }
        public async Task<GdSerieViewModel> GetByIdGdSerieViewModel(int id)
        {
            var SerieOnly = await _serieRepository.GetByIdAsync(id);
            GdSerieViewModel Gd = new();
            Gd.Id = SerieOnly.Id;
            Gd.Name = SerieOnly.Name;
            Gd.Description = SerieOnly.Description;
            Gd.CategoryId = SerieOnly.CategoryId;
            Gd.Productora = SerieOnly.Productora;
            Gd.Genero = SerieOnly.Genero;
            Gd.Trailer = SerieOnly.Trailer;
            Gd.Imagen = SerieOnly.Imagen;

            return Gd;
        }
        public async Task<GeneroViewModel> GetByIdGeneroViewmodel(int id)
        {
            var SerieOnly = await _serieRepository.GetByIdAsync(id);
            GeneroViewModel Gd = new();
            Gd.Id = SerieOnly.Id;
            Gd.Generos = SerieOnly.Genero;
          
            return Gd;
        }

        public async Task Delete(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);
            await _serieRepository.DeleteAsync(serie);
        }
        public async Task<List<SerieViewModel>> GetAllViewModel()
        {
            var SerieLis = await _serieRepository.GetAllAsync();
            return SerieLis.Select(Series => new SerieViewModel
            {
                Name = Series.Name,
                Id = Series.Id,
                Genero = Series.Genero,
                Imagen = Series.Imagen,
                Description = Series.Description,
                Productora = Series.Productora,
                Trailer = Series.Trailer,

            }).ToList();


        }

    }
}
