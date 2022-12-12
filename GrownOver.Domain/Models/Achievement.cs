namespace GrownOver.Domain.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<UserAchievement>? UserAchievements { get; set; }
    }
}
