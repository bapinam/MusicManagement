using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace MusicManagement.Albums
{
    public class AlbumIdAlreadyExistsException : BusinessException
    {
        public AlbumIdAlreadyExistsException(string id)
            : base(MusicManagementDomainErrorCodes.IdAlreadyExists)
        {
            WithData("id", id);
        }
    }
}