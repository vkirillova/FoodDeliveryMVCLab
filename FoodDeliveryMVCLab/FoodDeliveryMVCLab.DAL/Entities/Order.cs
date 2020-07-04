using System;

namespace ClassLibrary.DAL.Entities
{
    public class Order: IEntity
    {
        public int Id { get; set; }
        public string ShoppingCart { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }

    }
}