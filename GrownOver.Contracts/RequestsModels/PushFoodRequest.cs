using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Contracts.RequestsModels
{
    public class PushFoodRequest
    {
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public int Weight { get; set; }
        public int Energy { get; set; }
        public int Loot { get; set; }
    }
}
