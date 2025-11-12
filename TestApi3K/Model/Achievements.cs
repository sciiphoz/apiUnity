using System.ComponentModel.DataAnnotations;

namespace TestApi3K.Model
{
    public class Achievements
    {
        [Key]
        public int id_Achievement { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public virtual ICollection<UsersRecord> UserAchievements { get; set; } = new List<UsersRecord>();
    }
}
