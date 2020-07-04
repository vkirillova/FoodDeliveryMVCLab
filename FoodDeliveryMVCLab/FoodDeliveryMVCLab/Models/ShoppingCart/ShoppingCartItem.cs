using FoodDeliveryMVCLab.DAL.Entities;

namespace FoodDeliveryMVCLab.Models.ShoppingCart
{
    public class ShoppingCartItem
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
    }
}
