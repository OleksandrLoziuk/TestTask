using TestTask.API.Data.Interfaces;
using TestTask.API.Models;

namespace OnlineStore.API.Data.Interfaces
{
    public interface IOrderRepository: IDbRepository<Order>
    {
         
    }
}