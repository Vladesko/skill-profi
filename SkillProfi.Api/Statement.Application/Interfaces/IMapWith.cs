using AutoMapper;

namespace Statements.Application.Interfaces
{
    public interface IMapWith<T>
    {
        //Create configuration from type <T>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
