using AutoMapper;
using saitynai_server.Data.Dtos.Advertisements;
using saitynai_server.Data.Dtos.Comments;
using saitynai_server.Data.Dtos.Games;

namespace saitynai_server.Data
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Game, GameDto>();
            CreateMap<GamePostDto, Game>();
            CreateMap<GameUpdateDto, Game>();

            CreateMap<Advertisement, AdvertisementDto>();
            CreateMap<AdvertisementPostDto, Advertisement>();
            CreateMap<AdvertisementUpdateDto, Advertisement>();

            CreateMap<Comment, CommentDto>();
            CreateMap<CommentPostDto, Comment>();
            CreateMap<CommentUpdateDto, Comment>();
        }
    }
}
