namespace Clinic_IndividualWork_KazanovAlexandr.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Salary { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; } = new List<Doctor>();
    }
}
