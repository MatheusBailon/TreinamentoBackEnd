using SpauserControl.Infrastructure.Data.Map;
using SpaUserControl.Domain.Models;
using System.Data.Entity;

namespace SpauserControl.Infrastructure.Data
{
    //Organiza e trabalha todo o contexto de dados
    public class AppDataContext : DbContext
    {
        //Conection Strig será definido no construtor
        public AppDataContext() :base("AppConnectionString")
        {
            //Carrega os dados por partes(recupera os dados de objetos internos automaticamente)
            Configuration.LazyLoadingEnabled = false;
            //Para serealizar o JSON em caso de retorno do proxy ao invés do objeto em si.
            Configuration.ProxyCreationEnabled = false;
        }

        //Lista de usuário recuperados da base
        public DbSet<User> Users { get; set; }

        //Faz a referencia ao mapeamento do usuário
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
