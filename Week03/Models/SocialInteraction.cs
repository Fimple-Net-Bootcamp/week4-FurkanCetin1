namespace Week03.Models
{
    public class SocialInteraction
    {
        public int Id { get; set; }
        public int InitiatorPetId { get; set; }
        public int ParticipantPetId { get; set; }
        public DateTime Date { get; set; }
    }
}
