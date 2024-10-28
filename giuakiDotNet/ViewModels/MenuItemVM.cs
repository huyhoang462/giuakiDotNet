namespace giuakiDotNet.ViewModels
{
    public class MenuItemVM
    {
        public int MenuItemId { get; set; }

        public string Name { get; set; } = null!;

        public string? Image { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int? SubCategoryId { get; set; }
    }
}
