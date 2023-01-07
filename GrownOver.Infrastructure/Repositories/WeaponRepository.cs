using GrownOver.Application.Interfaces;
using GrownOver.Application.ViewModels;
using GrownOver.Domain.Models;
using GrownOver.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Infrastructure.Repositories
{
    public class WeaponRepository : IWeaponRepository
    {
        public readonly GrownOverDbContext _context;

        public WeaponRepository(GrownOverDbContext context)
        {
            _context = context;
        }

        public async Task<Weapon> GetWeapon(int id)
        {
            var weapon = _context.Weapons.Find(id);
            return weapon;
        }
    }
}
