using System.Collections.Generic;
using System.Threading.Tasks;
using FoodDeliveryMVCLab.DAL.Entities;
using FoodDeliveryMVCLab.Models.Orders;

namespace FoodDeliveryMVCLab.Services.Orders
{
    public interface IOrderService
    {
        Task CleanShoppingCartAsync(int dishId, User user);
        OrderCreateModel GetOrderCreateModel(int productId);
        FoodDeliveryMVCLab.DAL.Entities.Order CreateOrder(OrderCreateModel model);
        List<OrderViewModel> GetOrdersList();
    }
}
