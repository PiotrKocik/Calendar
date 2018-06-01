using AutoMapper;
using Calendar.Core.Models;
using Calendar.Infrastructure.ViewModels;

namespace Calendar.Mapper
{
    public class Automapper : Profile
    {
        public Automapper()
        {

            this.CreateMap<Payments, PaymentsViewModels>();
            this.CreateMap<PaymentsViewModels, Payments>()
                .ForMember(x => x.Months, y => y.Ignore());
            this.CreateMap<PaymentEditViewModels, Payments>()
                .ForMember(x=>x.MonthName,y=>y.Ignore())
                .ForMember(x => x.MonthsId, y => y.Ignore());
            this.CreateMap<Months, MonthsViewModels>().ReverseMap();
            this.CreateMap<PaymentMonthlyCreateViewModels, Payments>()
                .ForMember(x => x.MonthsId, y => y.Ignore());

            this.CreateMap<Payments, PaymentsAddViewModels>();
            this.CreateMap<PaymentsAddViewModels, Payments>()
                .ForMember(x=>x.Id,y=>y.Ignore())
                .ForMember(x => x.MonthName, y => y.Ignore())
                .ForMember(x => x.Months, y => y.Ignore())
                .ForMember(x => x.MonthsId, y => y.Ignore());

            this.CreateMap<Months, MonthsViewModels>().ReverseMap();
        }
    }
}