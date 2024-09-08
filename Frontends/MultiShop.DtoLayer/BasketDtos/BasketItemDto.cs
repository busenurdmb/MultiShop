using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.BasketDtos
{
    public class BasketItemDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductImageUrl { get; set; }

        public BasketItemDto(string productId, string productName, string imageUrl, int quantity, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            ProductImageUrl = imageUrl;
            Quantity = quantity;
            Price = price;
        }

        public BasketItemDto()
        {

        }


        public void UpdateOrderItems(string productId, string updatedName, string imageUrl, int quantity, decimal price)
        {
            ProductId = productId;
            ProductName = updatedName;
            ProductImageUrl = imageUrl;
            Quantity = quantity;
            Price = price;

        }

    }
}
