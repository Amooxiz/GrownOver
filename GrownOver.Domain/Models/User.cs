using Microsoft.AspNetCore.Identity;

namespace GrownOver.Domain.Models
{
    public class User : IdentityUser
    {
        public string nickName { get; set; }
        public int? Health { get; set; }
        public int? Efficiency { get; set; }
        public int? Power { get; set; }
        public int? Ingenuity { get; set; }
        public int? Charisma { get; set; }
        public int? Awereness { get; set; }
        public int? Experience { get; set; }
        public virtual HideOut? HideOut { get; set; }
        public virtual Inventory? Inventory { get; set; }
        public virtual ICollection<UserAchievement>? UserAchievements { get; set; }
    }
}
