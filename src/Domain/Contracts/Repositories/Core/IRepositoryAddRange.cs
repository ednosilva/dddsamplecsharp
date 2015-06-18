using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Contracts.Repositories.Core
{
    //Princípio da Segregação de Interface.
    //Apenas o método de adicionar vários.
    //Utilizamos Generics e um filtro para permitir apenas Entidades.
    public interface IRepositoryAddRange<in TEntity, TCodigo>
        where TEntity : Entities.Core.Entity<TCodigo>
        where TCodigo : struct
    {
        void AddRange(IEnumerable<TEntity> entities);
    }
}
