using OnlineStore.API.Data.Interfaces;
using TestTask.API.Data.Generic;
using TestTask.API.Models;

namespace TestTask.API.Data.Repositories
{
    public class OrderRepository: DbRepository<Order>, IOrderRepository
    {
         public OrderRepository(DataContext context) : base(context)
        {
        }
    }
}