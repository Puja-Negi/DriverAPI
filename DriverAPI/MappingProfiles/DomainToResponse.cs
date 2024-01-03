using AutoMapper;
using Driver.Entities.DbSet;
using Driver.Entities.Dtos.Requests;
using Driver.Entities.Dtos.Responses;

namespace DriverAPI.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse() 
        {
            CreateMap<Achievement, DriverAchievementResponse>()
                    .ForMember(
                               dest => dest.Wins,
                               opt => opt.MapFrom(src => src.RaceWins))
                    ;
            CreateMap < Driver.Entities.DbSet.Driver, GetDriverResponse>()
                .ForMember(
                               dest => dest.DriverId,
                               opt => opt.MapFrom(src => src.Id))
                 .ForMember(
                               dest => dest.FullName,
                               opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                    ;
        }
    }
}
