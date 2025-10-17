namespace TrainingProgramWebApi.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        // crud operations
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

    }
}
