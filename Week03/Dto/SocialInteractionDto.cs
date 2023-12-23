namespace Week03.Dto
{
    public class SocialInteractionDto
    {
        public int Id { get; set; }
        public int InitiatorPetId { get; set; }
        public int ParticipantPetId { get; set; }
        public DateTime Date { get; set; }
    }
}
