using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllEars.Server.Entities
{
    public class Billing
    {
        [Key]
        public int billing_id { get; set; }

        [ForeignKey("Patient")]
        public int patientId { get; set; }

        [ForeignKey("ClinicalPsychologist")]
        public int clinicalDoctorId { get; set; }

        [ForeignKey("BookAppointment")]
        public int appointment_id { get; set; }

        public double bill_price { get; set; }

        [Required]
        [Column("paymentstatus")]
        public PaymentStatus paymentstatus { get; set; }

        // Navigation properties
        //public Patient Patient { get; set; }
        //public ClinicalPsychologist ClinicalPsychologist { get; set; }
        //public BookAppointment BookAppointment { get; set; }

        // Default constructor
        public Billing() { }

        // Parameterized constructor
        public Billing(int billing_id, int patientId, int clinicalDoctorId, int appointment_id, double bill_price, PaymentStatus paymentstatus)
        {
            this.billing_id = billing_id;
            this.patientId = patientId;
            this.clinicalDoctorId = clinicalDoctorId;
            this.appointment_id = appointment_id;
            this.bill_price = bill_price;
            this.paymentstatus = paymentstatus;
        }
    }

    public enum PaymentStatus
    {
        paid,
        unpaid,
        cancelled
    }
}
