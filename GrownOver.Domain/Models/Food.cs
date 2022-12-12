namespace GrownOver.Domain.Models
{
    public class Food : BaseItem
    {
        public int Energy { get; set; }
        public virtual ICollection<Inventory>? Inventories { get; set; }
    }
}
