using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Contracts.Repositories
{
    //Repositório de Sistema apenas com as funcionalidades necessárias
    public interface ISistemaRepository :
        Core.IRepositoryReadSingle<Entities.SistemaEntity, int>,
        Core.IRepositoryAdd<Entities.SistemaEntity, int>
    {

    }
}
