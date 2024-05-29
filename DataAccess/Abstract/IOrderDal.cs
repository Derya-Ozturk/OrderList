using Core;
using Core.DataAccess;
using Entities.Dtos;
using Entities.Entities;

namespace DataAccess.Abstract
{
    public interface IOrderDal: IEntityRepository<Order>
    {
        Task<PaginationList<Order>> GetOrderList(OrderDto orderDto);

    }
}
