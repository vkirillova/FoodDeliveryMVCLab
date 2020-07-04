using FoodDeliveryMVCLab.DAL.Entities;

namespace FoodDeliveryMVCLab.Models.Dishes
{
    public class DishRestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
