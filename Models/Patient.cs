namespace Clinic_IndividualWork_KazanovAlexandr.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set;}
        public string? Complaints { get; set; }
        public virtual ICollection<OutpatientCard> OutpatientCard { get; set; } = new List<OutpatientCard>();
    }
}
