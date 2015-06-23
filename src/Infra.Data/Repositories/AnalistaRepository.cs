using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BM.GestaoProblema.Infra.Data.Extensions;

namespace BM.GestaoProblema.Infra.Data.Repositories
{
    //Repositório de Analista.
    //Implementação da interface IAnalistaRepository.
    public sealed class AnalistaRepository
        : Domain.Contracts.Repositories.IAnalistaRepository
    {
        //Variáveis para representação da injeção de dependência.
        private readonly Contexts.GestaoProblemaContext _context;

        //Injetamos o contexto para a execução no contexto.
        public AnalistaRepository(Contexts.GestaoProblemaContext context)
        {
            //Repasse da injeção.
            _context = context;
        }

        public Domain.Entities.AnalistaEntity GetByCodigo(int codigo)
        {
            return _context.AnalistaEntities.SingleOrDefault(x => x.Codigo == codigo);
        }

        public void Add(Domain.Entities.AnalistaEntity entity)
        {
            _context.AnalistaEntities.Add(entity);
            //O .SaveChanges() será executado no UnitOfWork.
        }

        public void Update(Domain.Entities.AnalistaEntity entity)
        {
            _context.Update(entity);
            //O .SaveChanges() será executado no UnitOfWork.
        }
    }
}