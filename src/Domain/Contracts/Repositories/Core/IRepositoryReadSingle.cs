using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Contracts.Repositories.Core
{
    //Princípio da Segregação de Interface.
    //Apenas o método de ler apenas 1 registro pelo código.
    //Utilizamos Generics e um filtro para permitir apenas Entidades.
    public interface IRepositoryReadSingle<out TEntity, in TCodigo>
        where TEntity : Entities.Core.Entity<TCodigo>
        where TCodigo : struct
    {
        TEntity GetByCodigo(TCodigo codigo);
    }
}
