using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Contracts.Services.Core
{
    //Interface responsável pelo serviço de cadastrar um entidade.
    //Nem sempre este método atenderá a funcionalidade de cadastrar, 
    // pois há situações onde queremos realizar validações na hora da criação do objeto.
    public interface ICadastrarDomainService<in TEntity, TCodigo>
        where TEntity : Entities.Core.Entity<TCodigo>
        where TCodigo : struct
    {
        void Cadastrar(TEntity entity);
    }
}
