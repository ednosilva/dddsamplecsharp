using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Contracts.Repositories
{
    //Repositório de Time de Suporte apenas com as funcionalidades necessárias
    public interface ITimeSuporteRepository :
        Core.IRepositoryReadSingle<Entities.TimeSuporteEntity, int>,
        Core.IRepositoryAdd<Entities.TimeSuporteEntity, int>
    {
    }
}
