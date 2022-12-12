namespace GrownOver.Domain.Models
{
    public class UserAchievement
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int AchievementId { get; set;}
        public Achievement Achievement { get; set;}
    }
}