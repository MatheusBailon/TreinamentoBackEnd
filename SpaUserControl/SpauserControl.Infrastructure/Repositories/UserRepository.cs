using SpauserControl.Infrastructure.Data;
using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Models;
using System;
using System.Linq;

namespace SpauserControl.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDataContext _context = new AppDataContext();
        public User Get(string email)
        {
            return _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public User Get(Guid id)
        {
           //First = será execudado uma exceção caso o usuário não seja encontado
           //FisstOrDefault = será retornado null se o usuário não for encontrado
            return _context.Users.Where(x => x.Id==id).FirstOrDefault();
        }
        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void Update(User user)
        {
            //Com o State conseguimos saber se foi felta alguma modificação e o proprio entity framework armazena isso no banco
            _context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        //Finaliza a conexão
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
