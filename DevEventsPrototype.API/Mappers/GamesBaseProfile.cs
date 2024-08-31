using AutoMapper;
using GamesBasePrototype.API.Entities;
using GamesBasePrototype.API.Models;

namespace GamesBasePrototype.API.Mappers
{
    public class GamesBaseProfile : Profile
    {
        public GamesBaseProfile()
        {
            CreateMap<GamesBase, GamesBaseViewModel>();
            CreateMap<GamesBaseDev, GamesBaseDevViewModel>();

            CreateMap<GamesBaseInputModel, GamesBase>();
            CreateMap<GamesBaseDevInputModel, GamesBaseDev>();
        }
    }
}
