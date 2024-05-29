using AutoMapper;
using Business.Abstract;
using Core;
using DataAccess.Abstract;
using Entities.Dtos;

namespace Business.Concrete
{
    public class OrderManager: IOrderService
    {
        private readonly IMapper _mapper;
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal, IMapper mapper) 
        {
            _orderDal = orderDal;
            _mapper = mapper;
        }

        //public async Task<List<OrderDto>> GetOrderList()
        //{
        //    var orderList = await _orderDal.GetOrderList2();

        //    return _mapper.Map<List<OrderDto>>(orderList);
        //}

        public async Task<PaginationList<OrderDto>> OrderList(OrderDto orderDto)
        {
            var orderList = await _orderDal.GetOrderList(orderDto);
            
            var dtoList = _mapper.Map<List<OrderDto>>(orderList.Data);

            PaginationList<OrderDto> paginationList = new(dtoList, orderDto.PageNumber, orderDto.PageSize, orderList.TotalRecords);
            
            return paginationList;
            
        }
    }
}
