using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace MusicManagement.Authors
{
    public class AuthorAlreadyExistsException : BusinessException
    {
        public AuthorAlreadyExistsException(string name)
            : base(MusicManagementDomainErrorCodes.NameAlreadyExists)
        {
            WithData("name", name);
        }
    }
}