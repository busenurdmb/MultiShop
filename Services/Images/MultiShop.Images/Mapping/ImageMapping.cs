using AutoMapper;
using MultiShop.Images.Dtos;
using MultiShop.Images.Entities;

namespace MultiShop.Images.Mapping
{
    public class ImageMapping : Profile
    {
        public ImageMapping()
        {
            CreateMap<CreateImageDto, ImageDrive>().ReverseMap();
            CreateMap<ResultImageDto, ImageDrive>().ReverseMap();
            CreateMap<UpdateImageDto, ImageDrive>().ReverseMap();
        }
    }
}
