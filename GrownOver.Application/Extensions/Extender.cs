using GrownOver.Application.ViewModels;
using GrownOver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.Extensions
{
    public static class Extender
    {
        public static IQueryable<UserVM> ToModel(this IQueryable<User> users)
        {
            return users.Select(a => new UserVM
            {
                Id = a.Id,
                UserName = a.UserName,
                Health = a.Health,
                Efficiency = a.Efficiency,
                Power = a.Power,
                Ingenuity = a.Ingenuity,
                Charisma = a.Charisma,
                Awereness = a.Awereness,
                Experience = a.Experience,
                HideOutId = a.HideOutId,
                InventoryId = a.InventoryId,
                PointsLeft = a.PointsLeft

            });
        }
    }
}
