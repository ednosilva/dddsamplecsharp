using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Infra.Data.Repositories
{
    //Repositório de Chamado.
    //Implementação da interface IChamadoRepository.
    public sealed class ChamadoRepository
        : Domain.Contracts.Repositories.IChamadoRepository
    {
        //Variáveis para representação da injeção de dependência.
        private readonly Contexts.GestaoProblemaContext _context;

        //Injetamos o contexto para a execução no contexto.
        public ChamadoRepository(Contexts.GestaoProblemaContext context)
        {
            //Repasse da injeção.
            _context = context;
        }

        public Domain.Entities.ChamadoEntity GetByCodigo(Guid codigo)
        {
            return _context.ChamadoEntities.SingleOrDefault(x => x.Codigo == codigo);
        }

        public void Add(Domain.Entities.ChamadoEntity entity)
        {
            _context.ChamadoEntities.Add(entity);
            //O .SaveChanges() será executado no UnitOfWork.
        }

        public void Update(Domain.Entities.ChamadoEntity entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            //O .SaveChanges() será executado no UnitOfWork.
        }
    }
}
