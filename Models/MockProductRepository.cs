namespace VyTrongQuy_5405_Tuan2.Models
{
    public class MockProductRepository : IProductRepository
    {
        private readonly List<Product> _products;
        public MockProductRepository()
        {
            // Tạo một số dữ liệu mẫu
            _products = new List<Product>
             {
             new Product { Id = 1, Name = "MAC", Price = 1000, Description = "Number 1", CategoryId=1},
             new Product { Id = 2, Name = "WIN", Price = 2000, Description = "Number 2", CategoryId=2},
             new Product { Id = 3, Name = "XIAOMI", Price = 3000, Description = "Number 3", CategoryId=3},
             // Thêm các sản phẩm khác
             };
        }
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }
        public void Update(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index != -1)
            {
                _products[index] = product;
            }
        }
        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
