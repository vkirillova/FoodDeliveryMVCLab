using Microsoft.AspNetCore.Identity;

namespace FoodDeliveryMVCLab.DAL.Entities
{
    public class Role: IdentityRole<int>, IEntity
    {
    }
}
