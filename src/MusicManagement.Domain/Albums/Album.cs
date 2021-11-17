using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace MusicManagement.Albums
{
    public class Album : AuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public string Description { get; set; }

        private Album()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Album(
            Guid id,
            [NotNull] Guid creatorId,
            [NotNull] string name,
            [CanBeNull] string description = null)
            : base(id)
        {
            SetName(name);
            CreatorId = creatorId;
            Description = description;
        }

        internal Album ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: AlbumConsts.MaxNameLength
            );
        }
    }
}