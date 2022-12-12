namespace GrownOver.Domain.Models
{
    public class Material : BaseItem
    {
        public int Quality { get; set; }
        public virtual ICollection<Inventory>? Inventories { get; set; }
    }
}
