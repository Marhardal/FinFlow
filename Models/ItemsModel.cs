using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinFlow.Models
{
    public class ItemsModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Please select a category")]
        public int? CategoryId { get; set; } // For the selected category

        public ICollection<CategoryModel> Categories { get; set; } = new List<CategoryModel>();

        [ForeignKey("CategoryId")]
        public CategoryModel? Category { get; set; } // Navigation property

        public string Measurement { get; set; } = string.Empty;
    }
}
