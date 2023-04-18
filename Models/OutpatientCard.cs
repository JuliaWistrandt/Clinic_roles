namespace Clinic_IndividualWork_KazanovAlexandr.Models
{
    public class OutpatientCard
    {
        public int Id { get; set; }
        public string? TreatmentPlan { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;

    }
}
