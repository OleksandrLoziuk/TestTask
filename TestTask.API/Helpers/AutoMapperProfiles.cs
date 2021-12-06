using System.Linq;
using AutoMapper;
using TestTask.API.Dtos;
using TestTask.API.Models;

namespace TestTask.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<OrderDto, Order>();
        }
    }
}