namespace FinFlow.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public ICollection<ItemsModel>? Items { get; set; }

    }
}
