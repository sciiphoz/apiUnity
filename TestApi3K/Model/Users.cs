using System.ComponentModel.DataAnnotations;

namespace TestApi3K.Model
{
    public class Users
    {
        [Key]
        public int id_User { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Currency { get; set; }
    }
}
