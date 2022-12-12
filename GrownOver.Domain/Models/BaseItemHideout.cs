namespace GrownOver.Domain.Models
{
    public class BaseItemHideout
    {
        public int BaseItemId { get; set; }
        public BaseItem BaseItem { get; set; }
        public int HideoutId { get; set; }
        public HideOut HideOut { get; set; }
    }
}
