using System.ComponentModel.DataAnnotations;

namespace SEND_EMAIL_ASS._THROUGH_ENTITYFRAMEWORK.Entities
{
    public class Items
    {
        [Key]
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public int ItemPrice { get; set; }
    }
}
