using Core;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IOrderService
    {
        public Task<PaginationList<OrderDto>> OrderList(OrderDto orderDto);
        //public Task<List<OrderDto>> GetOrderList();
    }
}
