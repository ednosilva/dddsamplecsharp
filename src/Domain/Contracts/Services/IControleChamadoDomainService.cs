using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BM.GestaoProblema.Domain.Entities;
using BM.GestaoProblema.Domain.ValueObjects;

namespace BM.GestaoProblema.Domain.Contracts.Services
{
    //Serviço responsável pelas ações dos usuários
    // referente à abertura, atendimento e finalização do chamado.
    public interface IControleChamadoDomainService
    {
        ChamadoEntity Abrir(int codigoSistema, ChamadoPrioridadeValueObject prioridade);
        ChamadoEntity ColocarEmAtendimento(Guid codigoChamado, int codigoAnalista);
        ChamadoEntity Finalizar(Guid codigo);
    }
}
