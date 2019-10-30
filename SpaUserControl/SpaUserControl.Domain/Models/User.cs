using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaUserControl.Common.Validation;

namespace SpaUserControl.Domain.Models
{
    public class User
    {
        public User(string name,string email)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Email = email;
        }
        public Guid Id{ get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }
        public string  Password { get; private set; }

        public void InsertPassword(string password, string confirmPassword)
        {
            AssertionConcern.AssertArgumentNotNullOrEmpty(password,"Senha vazia");
            AssertionConcern.AssertArgumentNotNullOrEmpty(confirmPassword, "Confirmação de senha vazia");
            AssertionConcern.AssertArgumentEquals(password, confirmPassword,"Senhas são diferentes");
            AssertionConcern.AssertArgumentLength(password, 6, 20, "Tamanho da senha inválida");
            
            this.Password = PasswordAssertionConcern.Encrypt(password); ;
        }

        public string ResetPassword()
        {
            string password = Guid.NewGuid().ToString().Substring(0, 8);
            this.Password = password;

            return password;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }

        //Valida se o objeto instanciado está correto
        public void Valid()
        {
            AssertionConcern.AssertArgumentLength(this.Name, 3, 250, "Nome inválido");
            EmailAssertionConcern.Email(this.Email);
        }
    }
}
