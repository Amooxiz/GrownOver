using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.ViewModels
{
    public class ItemsVM
    {
        public List<ArmorVM>? armorVMs { get; set; }
        public List<WeaponVM>? weaponVMs { get; set; }
        public List<MaterialVM>? materialVMs { get; set; }
        public List<FoodVM>? foodVMs { get; set; }

    }
}
