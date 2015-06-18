using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Contracts.Repositories.Core
{
    //Princípio da Segregação de Interface.
    //Apenas o método de excluir.
    public interface IRepositoryDelete<in TCodigo>
        where TCodigo : struct
    {
        void DeleteByCodigo(TCodigo codigo);
    }
}
