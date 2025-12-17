using System.ComponentModel.DataAnnotations;

namespace API.Demo.Models
{
    public class Player
    {
        public string Id { get; set; }
        [MaxLength(10)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Age { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string Club { get; set; }
        public List<string> PreviousClubs { get; set; } = new List<string>();
    }
}
