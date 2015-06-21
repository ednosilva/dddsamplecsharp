using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Alias para as convenções:
using Conventions = System.Data.Entity.ModelConfiguration.Conventions;

namespace BM.GestaoProblema.Infra.Data.Contexts
{
    //Contexto do EntityFramework
    public sealed class GestaoProblemaContext : DbContext
    {
        #region Construtores
        public GestaoProblemaContext()
            //Pega a conexão "GestaoProblema" do WebConfig/AppConfig
            // do projeto que está sendo executado.
            //Se for executar algum comando no console, é necessário ter
            // o projeto com a conexão "setado" como StartUp Project.
            : base("GestaoProblema")
        //String de conexão na mão:
        //:base("Data Source=(localbd)\ProjectsV12;Initial Catalog=GestaoProblema;Integrated Security=true")
        {
            Configure();
        }

        //Definição da string de conexão ou nome da string de conexão por fora.
        public GestaoProblemaContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configure();
        }
        #endregion

        #region Propriedades
        //O DbSet<> "representa as tabelas" do banco.
        public DbSet<Domain.Entities.AnalistaEntity> AnalistaEntities { get; private set; }
        public DbSet<Domain.Entities.ChamadoEntity> ChamadoEntities { get; private set; }
        public DbSet<Domain.Entities.SistemaEntity> SistemaEntities { get; private set; }
        public DbSet<Domain.Entities.TimeSuporteEntity> TimeSuporteEntities { get; private set; }
        #endregion

        #region Configuração do EF
        //Método que realiza a configuração do contexto
        private void Configure()
        {
            //LazyLoading desabilitado:
            Configuration.LazyLoadingEnabled = false;

            //Criação de proxy desabilitada:
            Configuration.ProxyCreationEnabled = false;

            //Verificação de alteração automática do bando desabilitada:
            Configuration.AutoDetectChangesEnabled = false;
        } 
        #endregion

        #region Criação dos modelos (override OnModelCreating)
        //Sobrescrita do OnModelCreating.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Foi removido algunas convenções do EF
            #region Conventions
            //Remove One To Many Cascade Delete
            modelBuilder.Conventions.Remove<Conventions.OneToManyCascadeDeleteConvention>();

            //Remove Many To Many Cascade Delete
            modelBuilder.Conventions.Remove<Conventions.ManyToManyCascadeDeleteConvention>();

            //Remove Pluralização das tabelas
            modelBuilder.Conventions.Remove<Conventions.PluralizingTableNameConvention>();
            #endregion

            //Adiciona todos os mapeamentos das objetos
            #region Mappings
            modelBuilder.Configurations.Add(new Mappings.AnalistaMap());
            modelBuilder.Configurations.Add(new Mappings.ChamadoMap());
            modelBuilder.Configurations.Add(new Mappings.SistemaMap());
            modelBuilder.Configurations.Add(new Mappings.TimeSuporteMap());
            #endregion

            base.OnModelCreating(modelBuilder);
        } 
        #endregion
    }
}
