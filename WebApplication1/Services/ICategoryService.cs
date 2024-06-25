using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        int AddCategory(Category category);
        int EditCategory(Category category);
        int DeleteCategory(int id);
    }
}
