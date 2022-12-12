namespace GrownOver.Domain.Models
{
    public abstract class BaseItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public virtual ICollection<BaseItemHideout> BaseItemHideouts { get; set; }
    }
}
