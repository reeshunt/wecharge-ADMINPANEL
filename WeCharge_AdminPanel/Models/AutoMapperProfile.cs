using AutoMapper;
using WeCharge.Model;
using WeCharge.Model.DTO;

namespace WeCharge_AdminPanel.Models
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<UsersViewModel, Users>();
            CreateMap<Users, UsersViewModel>();

            CreateMap<TimeSlotViewModel, TimeSlot>();
            CreateMap<TimeSlot, TimeSlotViewModel>();

            CreateMap<OrdersViewModel, Orders>();
            CreateMap<Orders, OrdersViewModel>();
        }
            
    }
}
