using GrownOver.Application.ViewModels;
using GrownOver.Contracts.RequestsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.Interfaces
{
    public interface IBaseItemService
    {
        public ItemsVM GetAllItems();
        public void AddWeapon(PushWeaponRequest pushWeaponRequest);
        public void AddArmor(PushArmorRequest pushArmorRequest);
        public void AddMaterial(PushMaterialRequest pushMaterialRequest);
        public void AddFood(PushFoodRequest pushFoodRequest);
        public dynamic GetItem(int id, string type);
    }
}
