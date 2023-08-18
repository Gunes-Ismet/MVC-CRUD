using Microsoft.Build.Framework;
using MVC_CRUD.Models.Entities.Abstract;

namespace MVC_CRUD.Models.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
    }
}
