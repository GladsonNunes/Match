namespace Match.Domain.Core
{
    public interface IRepCore<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
        List<T> GetByIds(List<int> ids);
        List<T> GetAllById(int id);
    }
}
