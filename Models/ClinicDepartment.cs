namespace Clinic_IndividualWork_KazanovAlexandr.Models
{
    public class ClinicDepartment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    }
}
