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
    public sealed class ChamadoMap 
        : EntityTypeConfiguration<Domain.Entities.ChamadoEntity>
    {
        //A configuração deve ser feita no construtor da classe.
        public ChamadoMap()
        {
            ToTable("Chamado");
            HasKey(x => x.Codigo);

            Property(x => x.Codigo)
                .HasColumnName("ChamadoId")
                .HasColumnType("uniqueidentifier");

            HasOptional(x => x.AnalistaEmAtendimento)
                .WithMany()
                .HasForeignKey(x => x.CodigoAnalistaEmAtendimento)
                .WillCascadeOnDelete(false);

            Property(x => x.CodigoAnalistaEmAtendimento)
                .HasColumnName("AnalistaId")
                .HasColumnType("int");

            HasRequired(x => x.Sistema)
                .WithMany()
                .HasForeignKey(x => x.CodigoSistema)
                .WillCascadeOnDelete(false);

            Property(x => x.CodigoSistema)
                .HasColumnName("SistemaId")
                .HasColumnType("int");

            Property(x => x.DataCriacao)
                .HasColumnName("DataCriacao")
                .HasColumnType("smalldatetime")
                .IsRequired();

            Property(x => x.DataFinalizado)
                .HasColumnName("DataFinalizado")
                .HasColumnType("smalldatetime")
                .IsOptional();

            Property(x => x.DataInicioAtendimento)
                .HasColumnName("DataInicioAtendimento")
                .HasColumnType("smalldatetime")
                .IsOptional();

            Ignore(x => x.PrazoSolucao);

            Property(x => x.Prioridade)
                .HasColumnName("Prioridade")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Status)
                .HasColumnName("Status")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
