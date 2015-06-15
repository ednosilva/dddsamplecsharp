using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProblema.Domain.Contracts.Repositories.Core
{
    //Princípio da Segregação de Interface.
    //Apenas o método de atualizar.
    //Utilizamos Generics e um filtro para permitir apenas Entidades.
    public interface IRepositoryUpdate<in TEntity, TCodigo>
        where TEntity : Entities.Core.Entity<TCodigo>
        where TCodigo : struct
    {
        void Update(TEntity entity);
    }
}
