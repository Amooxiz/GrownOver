namespace GrownOver.Domain.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int? WeaponId { get; set; }
        public virtual Weapon? weapon { get; set; }
        public int? ArmorId { get; set; }
        public virtual Armor? armor { get; set; }
        public int? FoodId { get; set; }
        public virtual Food? food { get; set; }
        public int? MaterialId { get; set; }
        public virtual Material? material { get; set; }
    }
}
