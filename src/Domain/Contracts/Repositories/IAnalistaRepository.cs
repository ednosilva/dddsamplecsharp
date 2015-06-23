using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Contracts.Repositories
{
    //Repositório de Analista apenas com as funcionalidades necessárias
    public interface IAnalistaRepository :
        Core.IRepositoryReadSingle<Entities.AnalistaEntity, int>,
        Core.IRepositoryAdd<Entities.AnalistaEntity, int>,
        Core.IRepositoryUpdate<Entities.AnalistaEntity, int>
    {
    }
}
