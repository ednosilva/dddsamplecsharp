using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Contracts.Services.Core
{
    //Interface responsável pelo serviço de trocar o time de suporte de uma entidade.
    public interface ITrocarTimeSuporte<out TEntity, in TCodigo>
        where TEntity : Entities.Core.Entity<TCodigo>
        where TCodigo : struct
    {
        TEntity TrocarTimeSuporte(TCodigo codigo, int codigoTimeSuporte);
    }
}
