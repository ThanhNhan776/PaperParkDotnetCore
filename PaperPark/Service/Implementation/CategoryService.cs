using PaperPark.Entity;
using PaperPark.Repository.Interface;
using PaperPark.Service.Interface;

namespace PaperPark.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;
        private ICategoryRepository _categoryRepository;

        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public Category Get(int id)
        {
            return _categoryRepository.Get(id);
        }
    }
}