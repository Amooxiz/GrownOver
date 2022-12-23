using GrownOver.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.Interfaces
{
    public interface IWeaponService
    {
        public Task<WeaponVM> GetWeapon(int id);
    }
}
