using System.ComponentModel.DataAnnotations;

namespace AllEars.Server.Entities
{
    public class Admin
    {
        [Key]
        public int admin_id { get; set; }

        [Required]
        [MaxLength(255)]
        public string admin_name { get; set; }

        [Required]
        [MaxLength(255)]
        public string admin_email { get; set; }

        [Required]
        [MaxLength(50)]
        public string admin_password { get; set; }

        // Default constructor
        public Admin() { }

        // Parameterized constructor
        public Admin(int admin_id, string admin_name, string admin_email, string admin_password)
        {
            this.admin_id = admin_id;
            this.admin_name = admin_name;
            this.admin_email = admin_email;
            this.admin_password = admin_password;
        }
    }
}
