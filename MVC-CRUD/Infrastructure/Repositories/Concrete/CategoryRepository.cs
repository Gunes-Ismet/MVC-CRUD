using Microsoft.EntityFrameworkCore.Update.Internal;
using MVC_CRUD.Infrastructure.Context;
using MVC_CRUD.Infrastructure.Repositories.Interface;
using MVC_CRUD.Models.Entities.Concrete;
using System.Linq.Expressions;

namespace MVC_CRUD.Infrastructure.Repositories.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            category.Status = Models.Entities.Abstract.Status.Modified;
            category.UpdatedDate = DateTime.Now;
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            category.Status = Models.Entities.Abstract.Status.Passive;
            category.DeletedDate = DateTime.Now;
            _context.Categories.Update(category);
            _context.SaveChanges();
        }


        public List<Category> GetAll()
        {
            var categories = _context.Categories.Where(x => x.Status != Models.Entities.Abstract.Status.Passive).ToList();
            return categories;
        }

        public List<Category> GetByDefaults(Expression<Func<Category, bool>> expression)
        {
            var categories = _context.Categories.Where(expression).ToList();
            return categories;
        }

        public Category GetByDefault(Expression<Func<Category, bool>> expression)
        {
            var category = _context.Categories.FirstOrDefault(expression);
            return category;
        }

        public Category GetById(int id)
        {
            var category = _context.Categories.Find(id);
            return category;
        }

    }
}
