namespace Insurance.API.Models
{
    public class ClientDTO
    {
        public int ClientId { get; set; }

        public int Identification { get; set; }

        public string CompleteName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}