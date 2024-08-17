using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia , CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia , GetSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia , UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia , ResultSocialMediaDto>().ReverseMap();
        }
    }
}
