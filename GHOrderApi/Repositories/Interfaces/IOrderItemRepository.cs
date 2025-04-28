using GHOrderApi.Models;
using GHOrderApi.Repositories.Interfaces.Base;

namespace GHOrderApi.Repositories.Interfaces
{
    public interface IOrderItemRepository : IReadOnlyRepository<OrderItem>
    {
    }
}
