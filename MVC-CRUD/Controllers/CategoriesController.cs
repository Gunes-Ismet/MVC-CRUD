using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Infrastructure.Repositories.Interface;
using MVC_CRUD.Models.DTO_s;
using MVC_CRUD.Models.Entities.Concrete;

namespace MVC_CRUD.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index(string? value)
        {
            var categories = _categoryRepository.GetAll();
            //var categories = _categoryRepository.GetByDefaults(x => x.Status != Models.Entities.Abstract.Status.Passive);
            TempData["Success"] = value;
            return View(categories);
        }


        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = model.Name;
                category.Description = model.Description;
                _categoryRepository.Create(category);
                TempData["Success"] = "Kayıt başarılı!!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Formu kurallara uygun bir şekilde doldurunuz!";
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category is not null)
            {
                var model = new UpdateCategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                };
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateCategory(UpdateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                var category = _categoryRepository.GetById(model.Id);
                category.Name = model.Name;
                category.Description = model.Description;
                _categoryRepository.Update(category);
                TempData["Success"] = "Kategori güncellendi!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Formu kurallara uygun bir şekilde doldurunuz!";
            return View(model);
        }

        ////1. Yöntem
        //[HttpGet]
        //public IActionResult DeleteCategory(int id)
        //{
        //    var category = _categoryRepository.GetById(id);
        //    if (category is not null)
        //    {
        //        _categoryRepository.Delete(category);
        //        TempData["Success"] = "Kategori silindi!!";
        //        return RedirectToAction("Index");
        //    }
        //    return NotFound();
        //}

        //2.Yöntem
        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category is not null)
            {
                _categoryRepository.Delete(category);
                TempData["Success"] = "Kategori silindi!!";
                return RedirectToAction("Index");
            }
            return NotFound();
        }

    }
}
