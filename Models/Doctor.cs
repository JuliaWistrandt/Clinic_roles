namespace Clinic_IndividualWork_KazanovAlexandr.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }

        public int PositionId { get; set; }

        public virtual Position Position { get; set; } = null!;
        public virtual ICollection<OutpatientCard> OutpatientCard { get; set; } = new List<OutpatientCard>();
    }
}
