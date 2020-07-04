using Microsoft.AspNetCore.Identity;

namespace ClassLibrary.DAL.Entities
{
    public class User: IdentityUser<int>, IEntity
    {
        public string ShoppingCart { get; set; }
    }
}
