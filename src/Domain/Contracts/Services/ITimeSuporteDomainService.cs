using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Contracts.Services
{
    //Serviço responsável pelas ações dos usuários
    // referente à cadastro e atualização de um time de suporte.
    public interface ITimeSuporteDomainService
        : Core.ICadastrarDomainService<Entities.TimeSuporteEntity, int>
        , Core.IAtualizarDomainService<Entities.TimeSuporteEntity, int>
    {
    }
}
