using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Contracts.Services
{
    //Serviço responsável pelas ações dos usuários
    // referente à cadastro, atualização e troca de time de um sistema.
    public interface ISistemaDomainService
        : Core.ICadastrarDomainService<Entities.SistemaEntity, int>
        , Core.IAtualizarDomainService<Entities.SistemaEntity, int>
        , Core.ITrocarTimeSuporte<Entities.SistemaEntity, int>
    {
    }
}
