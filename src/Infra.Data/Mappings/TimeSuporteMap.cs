using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Infra.Data.Mappings
{
    //Mapeamento de objeto x tabela no Entity Framework.
    /* Detalhes:
     *  ToTable:                Nome da tabela
     *  HasKey:                 Primary Key - adiciona pk, not null e identity(1,1)
     *  Property:               Configuração da propriedade do objeto que está sendo mapeado
     *  HasColumnName:          Nome da coluna que será gerado no banco de dados
     *  HasColumnType:          Tipo da coluna que será gerado no banco de dados
     *  HasRequired:            Configuração de FK 1 pra 1 e 1 pra N - adiciona fk e not null
     *  HasOptional:            Configuração de FK 0/1 pra 1 e 0/1 pra N - adiciona fk e null
     *  WithMany:               Indica se tem ou não um objeto do outro lado que represente a FK
     *  HasForeignKey:          Indica qual a propriedade que será representada como FK
     *  WillCascadeOnDelete:    Indica se vai ou não ter cascade on delete
     *  IsRequired:             Indica que o campo vai ser not null
     *  HasMaxLength:           Indica quantos caracteres que o campo terá
     *  HasPrecision:           Indica a precisão em campos numéricos com casas decimais
     *  Ignore:                 Indica que não será gerada uma coluna para a propriedade informada
     */
    public sealed class TimeSuporteMap
        : EntityTypeConfiguration<Domain.Entities.TimeSuporteEntity>
    {
        public TimeSuporteMap()
        {
            ToTable("TimeSuporte");
            HasKey(x => x.Codigo);

            Property(x => x.Codigo)
                .HasColumnName("TimeSuporteId")
                .HasColumnType("int");

            Property(x => x.DataCriacao)
                .HasColumnName("DataCriacao")
                .HasColumnType("smalldatetime")
                .IsRequired();

            Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsRequired();

            Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
