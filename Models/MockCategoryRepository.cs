namespace VyTrongQuy_5405_Tuan2.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        private List<Category> _categoryList;
        public MockCategoryRepository()
        {
            _categoryList = new List<Category>
             {
             new Category { Id = 1, Name = "Laptop" },
             new Category { Id = 2, Name = "Desktop" },
             new Category { Id = 3, Name = "PC"},
             new Category { Id = 4, Name = "Mobile Phone"},
             new Category { Id = 5, Name = "Ipad"},
             new Category { Id = 6, Name = "Radio"}
             };
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryList;
        }
    }
}
