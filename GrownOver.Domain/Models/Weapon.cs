namespace GrownOver.Domain.Models
{
    public class Weapon : BaseItem
    {
        public float Durability { get; set; }
        public int Damage { get; set; }
        public virtual ICollection<Inventory>? Inventories { get; set; }
    }
}
