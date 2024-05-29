using Core;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, OkdbContext>, IOrderDal
    {
        private readonly OkdbContext _context;

        public EfOrderDal()
        {
            _context = new OkdbContext();
        }
        public async Task<PaginationList<Order>> GetOrderList(OrderDto orderDto)
        {
            IQueryable<Order> orderQuery = _context.Orders
                .Include(x => x.Creator)
                .Include(x => x.Customer)
                .Include(x => x.OrderStatus)
                .Include(x => x.SalesRepresentive).AsNoTracking();
           
            var orders = await orderQuery
                .Skip((orderDto.PageNumber - 1) * orderDto.PageSize)
                .Take(orderDto.PageSize)
                .ToListAsync();          

            var pagedResponse = new PaginationList<Order>(orders, orderDto.PageNumber, orderDto.PageSize, orderQuery.Count());

            return pagedResponse;
        }
    }
}
