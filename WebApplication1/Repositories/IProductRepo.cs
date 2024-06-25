using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        IEnumerable<Product> GetProductByName(string name);
        int AddProduct(Product product);
        int EditProduct(Product product);
        int DeleteProduct(int id);
    }
}
