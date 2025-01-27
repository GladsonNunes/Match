namespace Match.Domain.Core
{
    public interface IRepCore<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> GetByIds(List<int> ids);
    }
}
