using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Series>? Serie { get; set; }
    }
}
