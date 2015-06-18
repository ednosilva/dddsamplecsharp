using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Contracts.UnitsOfWork
{
    //Unidade de trabalho responsável por fazer o SaveChanges do GestaoProblemaContext.
    //Está herdando as assinaturas do core.
    public interface IGestaoProblemaContextUnitOfWork : Core.IUnitOfWork
    {
    }
}
