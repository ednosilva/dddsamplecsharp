using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProblema.Domain.Contracts.Repositories
{
    //Repositório de Chamado apenas com as funcionalidades necessárias
    public interface IChamadoRepository :
        Core.IRepositoryReadSingle<Entities.ChamadoEntity, Guid>,
        Core.IRepositoryAdd<Entities.ChamadoEntity, Guid>,
        Core.IRepositoryUpdate<Entities.ChamadoEntity, Guid>
    {
    }
}
