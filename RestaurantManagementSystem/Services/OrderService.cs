using RestaurantManagementSystem.Dtos;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Repository;
using RestaurantManagementSystem.Services.Interfaces;

namespace RestaurantManagementSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public OrderService(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            return orders.Select(o => new OrderDto
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                TableId = o.TableId,
                TotalAmount = o.TotalAmount,
                OrderDate = o.OrderDate,
                Status = o.Status
            }).ToList();
        }

        public async Task<OrderDto?> GetByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
                return null;

            return new OrderDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                TableId = order.TableId,
                TotalAmount = order.TotalAmount,
                OrderDate = order.OrderDate,
                Status = order.Status
            };
        }

        public async Task AddAsync(OrderDto dto)
        {
            var order = new Order
            {
                CustomerId = dto.CustomerId,
                TableId = dto.TableId,
                TotalAmount = dto.TotalAmount,
                OrderDate = dto.OrderDate,
                Status = dto.Status
            };

            await _orderRepository.AddAsync(order);
        }

        public async Task UpdateAsync(int id, OrderDto dto)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return;

            order.CustomerId = dto.CustomerId;
            order.TableId = dto.TableId;
            order.TotalAmount = dto.TotalAmount;
            order.OrderDate = dto.OrderDate;
            order.Status = dto.Status;

            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return;

            await _orderRepository.DeleteAsync(id);
        }
    }
}
