using SpaUserControl.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaUserControl.Domain.Contracts.Repositories
{
    //Herda do IDisposable para ter o metodo .Disposable para fechar a conexão com o banco sem esperar o garbage collector
    public interface IUserRepository:IDisposable
    {
        User Get(string email);
        User Get(Guid id);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
    }
}
