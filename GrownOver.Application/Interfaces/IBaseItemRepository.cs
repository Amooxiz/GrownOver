using GrownOver.Application.ViewModels;
using GrownOver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.Interfaces
{
    public interface IBaseItemRepository
    {
        public ItemsVM GetAllItems();
        public Weapon AddWeapon(Weapon weapon);
        public Armor AddArmor(Armor armor);
        public Material AddMaterial(Material material);
        public Food AddFood(Food food);
        public dynamic GetItem(int id, string type);
    }
}
