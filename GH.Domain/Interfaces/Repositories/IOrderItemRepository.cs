using GH.Domain.Entities;
using GH.Domain.Interfaces.Repositories.Base;

namespace GH.Domain.Interfaces.Repositories
{
    public interface IOrderItemRepository : IReadOnlyRepository<OrderItem>
    {
    }
}
