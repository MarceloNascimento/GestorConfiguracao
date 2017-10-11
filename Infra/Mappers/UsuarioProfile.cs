namespace Infra.Mappers
{
    using AutoMapper;
    using DTO;
    using Infra.Context;
    class UsuarioProfile : Profile
    {

        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDTO>()
            .ForMember(dest => dest.Codigo, map => map.MapFrom(source => source.codigo))
             .ForMember(dest => dest.Nome, map => map.MapFrom(source => source.nome))
             .ForMember(dest => dest.Login, map => map.MapFrom(source => source.nickName))
             .ForMember(dest => dest.Senha, map => map.MapFrom(source => source.senha))
             .AfterMap((dest, source) =>
             {
                 if (source != null)
                 {
                     if (dest.Perfil != null)
                     {
                         source.PerfilId = dest.Perfil.codigo;
                         source.PerfilNome = dest.Perfil.nome;
                     }


                 }
             }).ReverseMap().AfterMap((source,dest) =>
             {
                 if (source != null)
                 {
                     if (source.PerfilNome != null)
                     {
                         dest.Perfil = new Perfil();
                         dest.Perfil.codigo = source.PerfilId;
                         dest.Perfil.nome = source.PerfilNome;
                     }

                 }
             });
        }

    }
}
