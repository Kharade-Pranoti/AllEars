using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllEars.Server.Entities
{
    public class ClinicalPsychologist
    {
        [Key]
        public int clinicalDoctor_id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255, ErrorMessage = "Name cannot exceed 255 characters")]
        public string clinicalDoctor_name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
        public string clinicalDoctor_email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(50, ErrorMessage = "Password cannot exceed 50 characters")]
        public string clinicalDoctor_password { get; set; }

        [Required(ErrorMessage = "Specialization is required")]
        [MaxLength(100, ErrorMessage = "Specialization cannot exceed 100 characters")]
        public string clinicalDoctor_specialization { get; set; }

        [Required(ErrorMessage = "Qualification is required")]
        [MaxLength(100, ErrorMessage = "Qualification cannot exceed 100 characters")]
        public string clinicalDoctor_qualification { get; set; }

        [ForeignKey("Category")]
        public int category_id { get; set; }

        public string address;

        public string imagedata; 

        // Navigation property to Category
        //public Category Category { get; set; }

        
        // List of availabilities for Clinical Psychologist
        //public ICollection<ClinicalDoctorAvailability> ClinicalDoctorAvailabilities { get; set; }

        //// List of BookAppointments
        //public ICollection<BookAppointment> BookAppointments { get; set; }

        //// List of Billings
        //public ICollection<Billing> Billings { get; set; }

        // Default constructor
        public ClinicalPsychologist() { }

        // Parameterized constructor
        public ClinicalPsychologist(int clinicalDoctor_id, string clinicalDoctor_name, string clinicalDoctor_email, string clinicalDoctor_password, string clinicalDoctor_specialization, string clinicalDoctor_qualification, int categ_id, string address,string imagedata)
        {
            this.clinicalDoctor_id = clinicalDoctor_id;
            this.clinicalDoctor_name = clinicalDoctor_name;
            this.clinicalDoctor_email = clinicalDoctor_email;
            this.clinicalDoctor_password = clinicalDoctor_password;
            this.clinicalDoctor_specialization = clinicalDoctor_specialization;
            this.clinicalDoctor_qualification = clinicalDoctor_qualification;
            this.category_id = categ_id;
            this.address = address;
            this.imagedata = imagedata;
        }
    }
}
