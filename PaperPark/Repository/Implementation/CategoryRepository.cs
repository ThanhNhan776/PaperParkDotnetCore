using Dapper;
using PaperPark.Entity;
using PaperPark.Repository.Interface;

namespace PaperPark.Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private IUnitOfWork _unitOfWork;

        public CategoryRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Category Get(int id)
        {
            var sql = @"SELECT * FROM Category
                        WHERE Id = @id";
            var param = new DynamicParameters();
            param.Add("@id", id);
            return _unitOfWork.Connection.QuerySingle<Category>(sql, param, _unitOfWork.Transaction);
        }

        public Category Create(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}