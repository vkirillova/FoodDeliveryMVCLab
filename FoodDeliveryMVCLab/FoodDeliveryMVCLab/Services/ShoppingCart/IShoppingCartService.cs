using System.Collections.Generic;
using System.Threading.Tasks;
using FoodDeliveryMVCLab.DAL.Entities;
using FoodDeliveryMVCLab.Models.ShoppingCart;

namespace FoodDeliveryMVCLab.Services.ShoppingCart
{
    public interface IShoppingCartService
    {
        Task AddToShoppingCartAsync(int productId, User user);
        List<ShoppingCartViewModel> CreateShoppingCart(int productId);
        List<ShoppingCartViewModel> UpdateShoppingCart(int productId, string currentBucket);
        List<ShoppingCartViewModel> GetShoppingCart(string currentCart);
    }
}