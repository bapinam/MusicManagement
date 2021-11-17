using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MusicManagement.Singers
{
    public interface ISingerRepository : IRepository<Singer, Guid>
    {
        Task<List<Singer>> GetListAsync(
           int skipCount,
           int maxResultCount,
           string filter = null
       );
    }
}