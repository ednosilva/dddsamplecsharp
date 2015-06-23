using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BM.GestaoProblema.Infra.Data.Extensions;

namespace BM.GestaoProblema.Infra.Data.Repositories
{
    //Repositório de Sistema.
    //Implementação da interface ISistemaRepository.
    public sealed class SistemaRepository
        : Domain.Contracts.Repositories.ISistemaRepository
    {
        //Variáveis para representação da injeção de dependência.
        private readonly Contexts.GestaoProblemaContext _context;

        //Injetamos o contexto para a execução no contexto.
        public SistemaRepository(Contexts.GestaoProblemaContext context)
        {
            //Repasse da injeção.
            _context = context;
        }

        public Domain.Entities.SistemaEntity GetByCodigo(int codigo)
        {
            return _context.SistemaEntities.SingleOrDefault(x => x.Codigo == codigo);
        }

        public void Add(Domain.Entities.SistemaEntity entity)
        {
            _context.SistemaEntities.Add(entity);
            //O .SaveChanges() será executado no UnitOfWork.
        }

        public void Update(Domain.Entities.SistemaEntity entity)
        {
            _context.Update(entity);
            //O .SaveChanges() será executado no UnitOfWork.
        }
    }
}
