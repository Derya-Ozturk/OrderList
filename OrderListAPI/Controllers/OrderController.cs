using Business.Abstract;
using Core;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OrderListAPI.Const;

namespace OrderListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        private IMemoryCache _cache;
        public OrderController(IOrderService orderService, IMemoryCache cache) 
        {
            _orderService = orderService;
            _cache = cache;
        }

        
        [Route("orderList")]
        [HttpPost]
        public async Task<ActionResult<PaginationList<OrderDto>>> GetOrderList(OrderDto orderDto) 
        {

            //if (_cache.TryGetValue(CacheInfo.orderKey, out PaginationList<OrderDto> list))
            //     return list;
            try
            {
                var response = await _orderService.OrderList(orderDto);
                return response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            //_cache.Set(CacheInfo.orderKey, response);
            
            
        }
   
    }
}
