using JetBrains.Annotations;
using MusicManagement.AuthorSongs;
using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace MusicManagement.Authors
{
    public class Author : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ImgPath { get; set; }

        private Author()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Author(
            Guid id,
            [NotNull] string name,
            DateTime birthDate,
            [CanBeNull] string description = null,
            [CanBeNull] string address = null,
            [CanBeNull] string imgPath = null)
            : base(id)
        {
            SetName(name);
            BirthDate = birthDate;
            Description = description;
            Address = address;
            ImgPath = imgPath;
        }

        internal Author ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: AuthorConsts.MaxNameLength
            );
        }
    }
}