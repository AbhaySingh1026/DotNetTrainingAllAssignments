using System.ComponentModel.DataAnnotations;

namespace SEND_EMAIL_ASS._THROUGH_ENTITYFRAMEWORK.Entities
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long Phone { get; set; }
        public string? Email { get; set; }
    }
}
