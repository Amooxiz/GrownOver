using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public int? PointsLeft { get; set; }
        public int? Health { get; set; }
        public int? Efficiency { get; set; }
        public int? Power { get; set; }
        public int? Ingenuity { get; set; }
        public int? Charisma { get; set; }
        public int? Awereness { get; set; }
        public int? Experience { get; set; }
        public int? HideOutId { get; set; }
        public int? InventoryId { get; set; }
    }
}
