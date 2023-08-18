using MVC_CRUD.Models.Entities.Concrete;
using System.Linq.Expressions;

namespace MVC_CRUD.Infrastructure.Repositories.Interface
{
    public interface ICategoryRepository
    {
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);

        //Read
        Category GetById(int id);
        Category GetByDefault(Expression<Func<Category, bool>> expression);

        List<Category> GetAll();
        List<Category> GetByDefaults(Expression<Func<Category, bool>> expression);
    }
}
