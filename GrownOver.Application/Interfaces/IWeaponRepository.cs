using GrownOver.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.Interfaces
{
    public interface IWeaponRepository
    {
        public Task<Weapon> GetWeapon(int id);
    }
}
