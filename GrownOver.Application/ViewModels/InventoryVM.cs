using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.ViewModels
{
    public class InventoryVM
    {
        public int Id { get; set; }
        public WeaponVM? weaponVM { get; set; }
        public ArmorVM? armorVM { get; set; }
        public FoodVM? foodVM { get; set; }
        public MaterialVM? materialVM { get; set; }
    }
}
