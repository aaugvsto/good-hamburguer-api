namespace GH.Domain.Interfaces.Repositories.Base
{
    public interface IReadOnlyRepository<T> where T : class
    {
        public T[] Get();
    }
}
