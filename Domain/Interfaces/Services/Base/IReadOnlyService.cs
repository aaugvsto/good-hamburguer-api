namespace GH.Domain.Interfaces.Services.Base
{
    public interface IReadOnlyService<T> where T : class
    {
        public T[] Get();
    }
}
