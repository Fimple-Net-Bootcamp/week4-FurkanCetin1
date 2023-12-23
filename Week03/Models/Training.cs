namespace Week03.Models
{
    public class Training
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public string? Type { get; set; }
        public DateTime Date { get; set; }
    }
}
