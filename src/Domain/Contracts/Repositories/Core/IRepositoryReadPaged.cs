using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProblema.Domain.Contracts.Repositories.Core
{
    //Princípio da Segregação de Interface.
    //Apenas o método de ler paginado.
    //Utilizamos Generics e um filtro para permitir apenas Entidades.
    interface IRepositoryReadPaged<out TEntity, TCodigo>
        where TEntity : Entities.Core.Entity<TCodigo>
        where TCodigo : struct
    {
        IEnumerable<TEntity> GetPaged(int skip, int take);
    }
}
