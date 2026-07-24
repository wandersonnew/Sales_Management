namespace Sales.Application.Interfaces.Repositories
{
    public interface IUnitOfWorkRepository
    {
        Task SaveAsync();
    }
}
