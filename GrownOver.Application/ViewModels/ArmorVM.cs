using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.ViewModels
{
    public class ArmorVM
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public int Weight { get; set; }
        public float Durability { get; set; }
        public int Resistance { get; set; }
    }
}
