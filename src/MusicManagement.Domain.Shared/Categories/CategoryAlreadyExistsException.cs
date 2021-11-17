using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace MusicManagement.Categories
{
    public class CategoryAlreadyExistsException : BusinessException
    {
        public CategoryAlreadyExistsException(string name)
            : base(MusicManagementDomainErrorCodes.NameAlreadyExists)
        {
            WithData("name", name);
        }
    }
}