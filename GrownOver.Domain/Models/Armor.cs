namespace GrownOver.Domain.Models
{
    public class Armor : BaseItem
    {
        public float Durability { get; set; }
        public int Resistance { get; set; }
        public virtual ICollection<Inventory>? Inventories { get; set; }
    }
}
