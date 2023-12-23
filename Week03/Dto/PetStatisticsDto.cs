namespace Week03.Dto
{
    public class PetStatisticsDto
    {
        public int PetId { get; set; }
        public int ActivityCount { get; set; }
        public DateTime? LastHealthCheckup { get; set; }
        public int FoodCount { get; set; }
    }
}
