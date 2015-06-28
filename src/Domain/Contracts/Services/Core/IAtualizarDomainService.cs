using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Contracts.Services.Core
{
    //Interface responsável pelo serviço de atualizar uma entidade.
    //Nem sempre este método atenderá a funcionalidade de atualizar, 
    // pois há situações onde queremos realizar validações na hora da alteração do objeto.
    public interface IAtualizarDomainService<in TEntity, TCodigo>
        where TEntity : Entities.Core.Entity<TCodigo>
        where TCodigo : struct
    {
        void Atualizar(TEntity entity);
    }
}
