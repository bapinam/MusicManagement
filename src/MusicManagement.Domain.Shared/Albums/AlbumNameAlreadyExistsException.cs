using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace MusicManagement.Albums
{
    public class AlbumNameAlreadyExistsException : BusinessException
    {
        public AlbumNameAlreadyExistsException(string name)
            : base(MusicManagementDomainErrorCodes.NameAlreadyExists)
        {
            WithData("name", name);
        }
    }
}