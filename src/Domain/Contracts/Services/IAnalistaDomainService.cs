using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Contracts.Services
{
    //Serviço responsável pelas ações dos usuários
    // referente à cadastro, atualização e troca de time de um analista.
    public interface IAnalistaDomainService
        : Core.ICadastrarDomainService<Entities.AnalistaEntity, int>
        , Core.IAtualizarDomainService<Entities.AnalistaEntity, int>
        , Core.ITrocarTimeSuporte<Entities.AnalistaEntity, int>
    {
    }
}
