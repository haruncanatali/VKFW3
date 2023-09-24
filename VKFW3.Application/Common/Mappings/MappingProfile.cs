using System.Reflection;
using AutoMapper;

namespace VKFW3.Application.Common.Mappings;

/*
 * Burada amaç AutoMapper profilini yapılandırmak ve IMapFrom<T> arabirimini uygulayan sınıfları otomatik olarak bulur
 *  ve bu sınıflar için eşleme kurallarını uygular.
 */


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i => 
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}