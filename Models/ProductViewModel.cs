using System;
using System.ComponentModel.DataAnnotations;

namespace TelerikGridMVC.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Price { get; set; }
        public Nullable<int> InStock { get; set; }
        public string Category { get; set; }
        public Nullable<int> Rating { get; set; }
        public string Country { get; set; }
        public Nullable<int> Units { get; set; }
        public string ProductName { get; set; }
    }
}
