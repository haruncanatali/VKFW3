using AutoMapper;

namespace VKFW3.Application.Common.Mappings;

public interface IMapFrom<T>
{   
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}