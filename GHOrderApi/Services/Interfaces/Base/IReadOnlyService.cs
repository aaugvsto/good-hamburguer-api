namespace GHOrderApi.Services.Interfaces.Base
{
    public interface IReadOnlyService<T> where T : class
    {
        public T[] Get();
    }
}
