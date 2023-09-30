﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    public class SerieViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Genero { get; set; }
        public string? Productora { get; set; }
        public string? Imagen { get; set; }
        public string? Trailer { get; set; }

        public int CategoryId { get; set; }

    }
}
