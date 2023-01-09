using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.ViewModels
{
    public class MaterialVM
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public int Weight { get; set; }
        public int Quality { get; set; }
        public int Loot { get; set; }
        public string? Type { get; set; }
    }
}
