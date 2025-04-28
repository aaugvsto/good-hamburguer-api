namespace GHOrderApi.Repositories.Interfaces.Base
{
    public interface IReadOnlyRepository<T> where T : class
    {
        public T[] Get();
    }
}
