using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllEars.Server.Entities
{
    public class ClinicalDoctorAvailability
    {
        [Key]
        public int cl_availability_id { get; set; }

        [ForeignKey("ClinicalPsychologist")]
        public int doctorId { get; set; }

        [Required]
        public DateTime cl_available_date { get; set; }

        [Required]
        public TimeSpan start_time { get; set; }

        [Required]
        public TimeSpan end_time { get; set; }

        // Navigation property
        //public ClinicalPsychologist ClinicalPsychologist { get; set; }

        // Default constructor
        public ClinicalDoctorAvailability() { }

        // Parameterized constructor
        public ClinicalDoctorAvailability(int cl_availability_id, int doctorId, DateTime cl_available_date, TimeSpan start_time, TimeSpan end_time)
        {
            this.cl_availability_id = cl_availability_id;
            this.doctorId = doctorId;
            this.cl_available_date = cl_available_date;
            this.start_time = start_time;
            this.end_time = end_time;
        }
    }
}
