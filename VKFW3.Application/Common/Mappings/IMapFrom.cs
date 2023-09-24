using AutoMapper;

namespace VKFW3.Application.Common.Mappings;

// Dto larda mapping işlemini kolauca override edebilmek için bu interface si yazdım. BookDto da kontrol edilebilir.
public interface IMapFrom<T>
{   
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}