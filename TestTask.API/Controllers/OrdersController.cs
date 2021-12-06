using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Interfaces;
using TestTask.API.Dtos;
using TestTask.API.Models;

namespace TestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;
        public OrdersController(IOrderRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _repo.AllItems.ToListAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _repo.GetItemAsync(id);
            return Ok(order);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrder(OrderDto orderForCreation)
        {
            if (orderForCreation != null)
            {
                var orderToCreation = _mapper.Map<Order>(orderForCreation);
                if (await _repo.AddItemAsync(orderToCreation))
                {
                    return Ok(orderToCreation);
                }
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpPut("{id}/edit")]
        public async Task<IActionResult> EditOrder(int id, OrderDto orderForCreation)
        {
            var order = await _repo.GetItemAsync(id);
            if (order != null)
            {
                _mapper.Map(orderForCreation, order);
                if (await _repo.SaveChangesAsync() > 0)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if(await _repo.DeleteItemAsync(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
