namespace GH.Domain.Interfaces.Services.Base
{
    public interface IService<T> where T : class
    {
        public T Add(T entity);
        public void Remove(int id);
        public T Update(T entity);
        public T[] Get();
    }
}
