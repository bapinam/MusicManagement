using System;
using System.ComponentModel.DataAnnotations;

namespace MusicManagement.Albums
{
    public class CreateAlbumDto
    {
        [Required]
        [StringLength(AlbumConsts.MaxNameLength)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public Guid Creator { get; set; }
    }
}