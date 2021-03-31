using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IRequestsRepository
    {
        Task<IEnumerable<Request>> GetAllAsync();
        Task<Request> GetRequestAsync(int id);
        Task CreateRequestAsync(Request request);
        void EditRequest(int id);
        Task RemoveRequestAsync(int id);
        Task<bool> SaveAsync();

        


    }
}
