using Microsoft.AspNetCore.Identity;

namespace FoodDeliveryMVCLab.DAL.Entities
{
    public class User: IdentityUser<int>, IEntity
    {
        public string ShoppingCart { get; set; }
    }
}
