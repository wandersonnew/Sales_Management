namespace Sales.Application.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<TEntity> GetOne(Guid id);

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> GetAllPaginated(int page, int pageSize);

        Task<int> Count();
    }
}
