using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC_CRUD.Models.DTO_s
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur!!")]
        [MaxLength(30, ErrorMessage = "30 karakter sınırını geçtiniz!!")]
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur!!")]
        [MaxLength(600, ErrorMessage = "600 karakter sınırını geçtiniz!!")]
        [DisplayName("Açıklama")]
        public string Description { get; set; }
    }
}
