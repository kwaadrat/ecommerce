using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.Models
{
    public class OrdersViewModel
    {
        [HiddenInput]
        public int? Id { get; set; }
        public string User { get; set; }
        public string Price { get; set; }
    }
}
