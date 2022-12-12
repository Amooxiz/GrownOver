namespace GrownOver.Domain.Models
{
    public class HideOut
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Capacity { get; set; }
        public int MaxCapacity { get; set; }
        public virtual ICollection<BaseItemHideout> BaseItemHideouts { get; set; }
    }
}
