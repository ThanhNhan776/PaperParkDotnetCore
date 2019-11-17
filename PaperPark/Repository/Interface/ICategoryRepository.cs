using PaperPark.Entity;

namespace PaperPark.Repository.Interface
{
    public interface ICategoryRepository
    {
        Category Get(int id);
        Category Create(Category category);
    }
}