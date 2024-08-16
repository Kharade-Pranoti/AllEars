using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllEars.Server.Entities
{
    public class Patient
    {
        [Key]
        public int patient_id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255, ErrorMessage = "Name cannot exceed 255 characters")]
        public string patient_name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
        public string patient_email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(50, ErrorMessage = "Password cannot exceed 50 characters")]
        public string patient_password { get; set; }

        [MaxLength(10, ErrorMessage = "Gender should not exceed 10 characters")]
        public string patient_gender { get; set; }

        public int patient_age { get; set; }

        [MaxLength(5, ErrorMessage = "Blood Group should not exceed 5 characters")]
        public string patient_bloodGroup { get; set; }

        [ForeignKey("Category")]
        public int category_id { get; set; }

        //// Navigation property to Category
        //public Category Category { get; set; }

        public string address { get; set; }

        // List of BookAppointments
        //public ICollection<BookAppointment> BookAppointments { get; set; }

        // List of Billings
        //public ICollection<Billing> Billings { get; set; }

        // Default constructor
        public Patient() { }

        // Parameterized constructor
        public Patient(int patient_id, string patient_name, string patient_email, string patient_password, string patient_gender, int patient_age, string patient_bloodGroup, int categ_id, string address)
        {
            this.patient_id = patient_id;
            this.patient_name = patient_name;
            this.patient_email = patient_email;
            this.patient_password = patient_password;
            this.patient_gender = patient_gender;
            this.patient_age = patient_age;
            this.patient_bloodGroup = patient_bloodGroup;
            this.category_id = categ_id;
            this.address = address;
        }
    }
}
