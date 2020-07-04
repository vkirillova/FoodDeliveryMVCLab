using Microsoft.AspNetCore.Identity;

namespace ClassLibrary.DAL.Entities
{
    public class Role: IdentityRole<int>, IEntity
    {
    }
}
