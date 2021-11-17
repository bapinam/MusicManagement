using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MusicManagement.Albums
{
    public class GetAlbumListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}