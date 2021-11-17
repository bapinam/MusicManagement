using AutoMapper;
using MusicManagement.Albums;

namespace MusicManagement
{
    public class MusicManagementApplicationAutoMapperProfile : Profile
    {
        public MusicManagementApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            //Album
            CreateMap<Album, AlbumDto>();
        }
    }
}