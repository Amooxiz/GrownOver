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
        public void AddWeapon(Weapon weapon);
        public void AddArmor(Armor armor);
        public void AddMaterial(Material material);
        public void AddFood(Food food);
        public dynamic GetItem(int id, string type);
    }
}
