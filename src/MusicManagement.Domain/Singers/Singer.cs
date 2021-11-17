using JetBrains.Annotations;
using MusicManagement.SingerSongs;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace MusicManagement.Singers
{
    public class Singer : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ImgPath { get; set; }

        private Singer()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Singer(
            Guid id,
            [NotNull] string name,
            [NotNull] Guid creatorId,
            DateTime birthDate,
            [CanBeNull] string description = null,
            [CanBeNull] string address = null,
            [CanBeNull] string imgPath = null)
            : base(id)
        {
            Name = name;
            BirthDate = birthDate;
            CreatorId = creatorId;
            Description = description;
            Address = address;
            ImgPath = imgPath;
        }
    }
}