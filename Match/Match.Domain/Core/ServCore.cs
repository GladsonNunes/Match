namespace Match.Domain.Core
{

    public class ServCore<T> : IServCore<T> where T : class
    {
        private readonly IRepCore<T> _rep;

        public ServCore(IRepCore<T> rep)
        {
            _rep = rep;
        }

        public List<T> GetAll()
        {
            return _rep.GetAll();
        }

        public T GetById(int id)
        {
            return _rep.GetById(id);
        }

        public T Add(T entity)
        {
            _rep.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _rep.Update(entity);
            return entity;
        }

        public void Delete(int id)
        {
            _rep.Delete(id);
        }
    }
}
