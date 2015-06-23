using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Contracts.Services.Core
{
    //Interface responsável pelo serviço de atualizar uma entidade.
    public interface IAtualizarDomainService<in TEntity, TCodigo>
        where TEntity : Entities.Core.Entity<TCodigo>
        where TCodigo : struct
    {
        void Atualizar(TEntity entity);
    }
}
