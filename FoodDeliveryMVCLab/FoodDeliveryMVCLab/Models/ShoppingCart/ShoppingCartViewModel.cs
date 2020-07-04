using FoodDeliveryMVCLab.DAL.Entities;

namespace FoodDeliveryMVCLab.Models.ShoppingCart
{
    public class ShoppingCartViewModel
    {
        public int DishId { get; set; }
        public string DishName { get; set; }
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string DishImage { get; set; }
    }
}
