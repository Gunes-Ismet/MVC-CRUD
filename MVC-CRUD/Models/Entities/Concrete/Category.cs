using MVC_CRUD.Models.Entities.Abstract;

namespace MVC_CRUD.Models.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
