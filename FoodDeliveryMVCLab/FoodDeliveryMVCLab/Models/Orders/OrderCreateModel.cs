using FoodDeliveryMVCLab.Models.Dishes;

namespace FoodDeliveryMVCLab.Models.Orders
{
    public class OrderCreateModel
    {
        public DishViewModel Product { get; set; }

        public int DishtId { get; set; }

        public int Amount { get; set; }

        public string Description { get; set; }
    }
}
