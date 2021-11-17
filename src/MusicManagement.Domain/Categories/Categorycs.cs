using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace MusicManagement.Categories
{
    public class Category : AuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public string Description { get; set; }

        private Category()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Category(
            Guid id,
            [NotNull] string name,
            [CanBeNull] string description = null)
            : base(id)
        {
            SetName(name);
            Description = description;
        }

        internal Category ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: CategoryConsts.MaxNameLength
            );
        }
    }
}