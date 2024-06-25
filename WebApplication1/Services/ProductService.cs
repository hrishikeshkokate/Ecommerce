using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo repo;

        public ProductService(IProductRepo repo)
        {
            this.repo = repo;
        }
        public int AddProduct(Product product)
        {
            return repo.AddProduct(product);
        }

        public int DeleteProduct(int id)
        {
            return repo.DeleteProduct(id);
        }

        public int EditProduct(Product product)
        {
            return repo.EditProduct(product);
        }

        public Product GetProductById(int id)
        {
            return repo.GetProductById(id);
        }

        public IEnumerable<Product> GetProductByName(string name)
        {
            return repo.GetProductByName(name);
        }

        public IEnumerable<Product> GetProducts()
        {
            return repo.GetProducts();
        }


    }
}
