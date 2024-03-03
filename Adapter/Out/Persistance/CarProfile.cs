using Hexagonal.Adapter.In.Web.DTO.Incoming;
using Hexagonal.Adapter.In.Web.DTO.Outgoing;
using Hexagonal.Adapter.Out.Persistance;
using Hexagonal.Application.Domain.Entity;

namespace Hexagonal.Adapter.In.Web.DTO.Profile
{
    public class CarProfile : AutoMapper.Profile
    {
        public CarProfile()
        {
            CreateMap<Car, GetCarDTO>().
                ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).
                ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model)).
                ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)).
                ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock));

            CreateMap<GetCarDTO, Car>().
                ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model)).
                ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)).
                ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).
                ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock));

            CreateMap<CreateCarDTO, Car>().
                ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model)).
                ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)).
                ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0)).
                ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock));

            CreateMap<Car, CarEfEntity>().
                ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model)).
                ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)).
                ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).
                ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock));

            CreateMap<CarEfEntity, Car>().
                ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model)).
                ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)).
                ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).
                ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock));
        }
    }
}
