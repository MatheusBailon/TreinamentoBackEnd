using SpaUserControl.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace SpauserControl.Infrastructure.Data.Map
{
    //Classe responsavel pelo Mapeamento da tabela de Usuários (User)
    //Isso significa que, as definições da tabela como o seu nome, o nome das colunas,
    //os tamanhos das colunas as chaves e relacionamentos são definidos nesta classe (nas classes de mapeamento)

    //Tudo que for ser realizado nesta tabela deve ser feito no construtor
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            //A definição do Guid do C# para a base de dados, no caso o SQL Server
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasMaxLength(160).IsRequired();

            //HasColumnAnnotation - Define propriedades da coluna, no exemplo abaixo estamos indexando o email e deixa como unique key
            Property(x => x.Email).HasColumnAnnotation(
                IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_EMAIL", 1) { IsUnique = true })
                );

            Property(x => x.Password).HasMaxLength(32).IsFixedLength();
        }
    }
}
