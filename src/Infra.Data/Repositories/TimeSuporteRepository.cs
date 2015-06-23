using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BM.GestaoProblema.Infra.Data.Extensions;

namespace BM.GestaoProblema.Infra.Data.Repositories
{
    //Repositório de Time de Suporte.
    //Implementação da interface ITimeSuporteRepository.
    public sealed class TimeSuporteRepository
        : Domain.Contracts.Repositories.ITimeSuporteRepository
    {
        //Variáveis para representação da injeção de dependência.
        private readonly Contexts.GestaoProblemaContext _context;

        //Injetamos o contexto para a execução no contexto.
        public TimeSuporteRepository(Contexts.GestaoProblemaContext context)
        {
            //Repasse da injeção.
            _context = context;
        }

        public Domain.Entities.TimeSuporteEntity GetByCodigo(int codigo)
        {
            return _context.TimeSuporteEntities.SingleOrDefault(x => x.Codigo == codigo);
        }

        public void Add(Domain.Entities.TimeSuporteEntity entity)
        {
            _context.TimeSuporteEntities.Add(entity);
            //O .SaveChanges() será executado no UnitOfWork.
        }

        public void Update(Domain.Entities.TimeSuporteEntity entity)
        {
            _context.Update(entity);
            //O .SaveChanges() será executado no UnitOfWork.
        }
    }
}
