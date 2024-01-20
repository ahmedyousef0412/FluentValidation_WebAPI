using AutoMapper;
using Fluent_Validation_WebAPI.Dtos;
using Fluent_Validation_WebAPI.Model;

namespace Fluent_Validation_WebAPI.Core.Mapping
{
	public class MappingProfile :Profile
	{
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
