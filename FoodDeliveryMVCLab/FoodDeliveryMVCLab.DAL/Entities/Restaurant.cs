using System.Collections.Generic;

namespace ClassLibrary.DAL.Entities
{
    public class Restaurant: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}