using System;
using Volo.Abp.Application.Dtos;

namespace MusicManagement.Albums
{
    public class AlbumDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime CreationTime { get; set; }
    }
}