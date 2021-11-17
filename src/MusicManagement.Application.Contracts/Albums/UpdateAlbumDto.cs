using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicManagement.Albums
{
    public class UpdateAlbumDto
    {
        [Required]
        [StringLength(AlbumConsts.MaxNameLength)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}