using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllEars.Server.Entities
{
    public class CounsellingPsychologist
    {
        [Key]
        public int counsellingDoctor_id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255, ErrorMessage = "Name cannot exceed 255 characters")]
        public string counsellingDoctor_name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
        public string counsellingDoctor_email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(50, ErrorMessage = "Password cannot exceed 50 characters")]
        public string counsellingDoctor_password { get; set; }

        [Required(ErrorMessage = "Specialization is required")]
        [MaxLength(100, ErrorMessage = "Specialization cannot exceed 100 characters")]
        public string counsellingDoctor_specialization { get; set; }

        [Required(ErrorMessage = "Qualification is required")]
        [MaxLength(100, ErrorMessage = "Qualification cannot exceed 100 characters")]
        public string counsellingDoctor_qualification { get; set; }

        [ForeignKey("Category")]
        public int category_id { get; set; }

        public string address;
        // Navigation property to Category
        //public Category Category { get; set; }


        // List of BookAppointments
        //public ICollection<BookAppointment> BookAppointments { get; set; }

        // Navigation property for CounsellingDoctorAvailabilities
        //public ICollection<CounsellingDoctorAvailability> CounsellingDoctorAvailabilities { get; set; }

        // Default constructor
        public CounsellingPsychologist() { }

        // Parameterized constructor
        public CounsellingPsychologist(int counsellingDoctor_id, string counsellingDoctor_name, string counsellingDoctor_email, string counsellingDoctor_password, string counsellingDoctor_specialization, string counsellingDoctor_qualification, int categ_id, string address)
        {
            this.counsellingDoctor_id = counsellingDoctor_id;
            this.counsellingDoctor_name = counsellingDoctor_name;
            this.counsellingDoctor_email = counsellingDoctor_email;
            this.counsellingDoctor_password = counsellingDoctor_password;
            this.counsellingDoctor_specialization = counsellingDoctor_specialization;
            this.counsellingDoctor_qualification = counsellingDoctor_qualification;
            this.category_id = categ_id;
            this.address = address;
        }
    }
}
