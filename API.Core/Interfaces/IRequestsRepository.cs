using API.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Core.Interfaces
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