using GrownOver.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrownOver.Application.ViewModels;

namespace GrownOver.Infrastructure.Services
{
    public class WeaponService : IWeaponService
    {
        public readonly IWeaponRepository _weaponRepository;
        public WeaponService(IWeaponRepository weaponRepository)
        { 
            _weaponRepository = weaponRepository;
        }

        public async Task<WeaponVM> GetWeapon(int id)
        {
            var weapon = await _weaponRepository.GetWeapon(id);

            WeaponVM weaponVM = new WeaponVM()
            {
                Id = weapon.Id,
                Name = weapon.Name,
                Description = weapon.Description,
                Durability = weapon.Durability,
                Damage = weapon.Damage,
                Price = weapon.Price,
                Weight = weapon.Weight,
            };

            return weaponVM;
        }
    }
}
