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

        public void Add(T entity)
        {
            _rep.Add(entity);
        }

        public void Update(T entity)
        {
            _rep.Update(entity);
        }

        public void Delete(int id)
        {
            _rep.Delete(id);
        }
    }
}
