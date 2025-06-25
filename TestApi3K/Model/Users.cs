using System.ComponentModel.DataAnnotations;

namespace TestApi3K.Model
{
    public class Users
    {
        [Key]
        public int id_User { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int level1score { get; set; } = 0;
        public int level2score { get; set; } = 0;
        public int level3score { get; set; } = 0;
    }
}
