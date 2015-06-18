using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Contracts.UnitsOfWork.Core
{
    //Pattern UnitOfWork. (Unidade de Trabalho)
    //Responsáveis pelas ações comuns.
    //Foi feito um core, pois o sistema pode trabalhar com mais
    // de uma conexão. Neste caso, cada conexão deve ter a sua
    // unidade de trabalho.
    //Implementamos o IDisposable para forçarmos a limpeza da memória.
    public interface IUnitOfWork : IDisposable
    {
        //Método que inicia a transação.
        void Begin();

        //Método que realiza o commit.
        void SaveChanges();
    }
}
