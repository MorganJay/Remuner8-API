using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class RequestsRepository : IRequestsRepository
    {
        private readonly Remuner8Context _remuner8Context;

        public RequestsRepository(Remuner8Context remuner8Context)
        {
            _remuner8Context = remuner8Context;
        }

        public async Task CreateRequestAsync(Request request)
        {
            await _remuner8Context.Requests.AddAsync(request);
        }

        public void EditRequest(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Request>> GetAllAsync()
        {
            var request = await _remuner8Context.Requests.ToListAsync();
            return request;
        }

        public async Task<Request> GetRequestAsync(int id)
        {
            var request = await _remuner8Context.Requests.FindAsync(id);
            return request;
        }

        public async Task RemoveRequestAsync(int id)
        {
            var request = await _remuner8Context.Requests.FindAsync(id);
            _remuner8Context.Requests.Remove(request);
        }

        public async Task<bool> SaveAsync()
        {
            return await _remuner8Context.SaveChangesAsync() >= 0;
        }
    }
}