using SpauserControl.Infrastructure.Data;
using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpauserControl.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDataContext _context = new AppDataContext();
        public User Get(string email)
        {
            throw new NotImplementedException();
        }

        public User Get(Guid id)
        {
            return _context.Users.Where(x => x.Id=id);
        }
        public void Create(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        //Finaliza a conexão
        public void Dispose()
        {
            _context.Dispose();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
