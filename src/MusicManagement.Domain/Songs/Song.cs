using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MusicManagement.Songs
{
    public class Song : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
    }
}