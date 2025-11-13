using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApi3K.Model
{
    public class UsersRecord
    {
        [Key]
        public int id_Record { get; set; }

        [Required]
        public int id_User { get; set; }

        [Required]
        public int id_Achievement { get; set; }

        [ForeignKey("id_User")]
        public virtual Users User { get; set; }
    }
}
