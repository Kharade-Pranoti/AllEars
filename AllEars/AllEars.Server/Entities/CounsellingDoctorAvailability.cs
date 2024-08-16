using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllEars.Server.Entities
{
    public class CounsellingDoctorAvailability
    {
        [Key]
        public int co_availability_id { get; set; }

        [ForeignKey("counselling_doctor_id")]
        public int therapistId { get; set; }

        //public CounsellingPsychologist CounsellingPsychologist { get; set; }

        [Required]
        public DateTime co_available_date { get; set; }

        [Required]
        public TimeSpan session_start_time { get; set; }

        [Required]
        public TimeSpan session_end_time { get; set; }

        // Default constructor
        public CounsellingDoctorAvailability() { }

        // Parameterized constructor
        public CounsellingDoctorAvailability(int co_availability_id, int therapistId, DateTime co_available_date, TimeSpan session_start_time, TimeSpan session_end_time)
        {
            this.co_availability_id = co_availability_id;
            this.therapistId = therapistId;
            this.co_available_date = co_available_date;
            this.session_start_time = session_start_time;
            this.session_end_time = session_end_time;
        }
    }
}
