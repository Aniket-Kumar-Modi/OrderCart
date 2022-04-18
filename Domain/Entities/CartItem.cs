using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class LineItem
    {
        [Key]
        public int LineItemId { get; set; }
        public int Id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public int CartId { get; set; }
        [JsonIgnore]
        public CartItem Cart { get; set; }

    }

    public class CartItem
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalAmount => Products.Select(k => k.price * k.quantity).Sum();
        public ICollection<LineItem> Products { get; set; }
    }
}
