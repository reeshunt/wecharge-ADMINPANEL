using AutoMapper;
using WeCharge.Model;

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
