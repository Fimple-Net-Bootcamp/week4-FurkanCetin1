using Newtonsoft.Json;

namespace Week03.Models
{
    public class ErrorDetail
    {
        public int Id { get; set; }
        public int? StatusCode { get; set; }
        public string? Message { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
