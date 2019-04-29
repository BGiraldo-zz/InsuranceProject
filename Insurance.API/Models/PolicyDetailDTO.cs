namespace Insurance.API.Models
{
    public class PolicyDetailDTO
    {
        public int PolicyDetailId { get; set; }

        public int PolicyId { get; set; }

        public int ClientId { get; set; }

        public bool Status { get; set; }

        public string PolicyName { get; set; }

        public string CustomerName { get; set; }
    }
}