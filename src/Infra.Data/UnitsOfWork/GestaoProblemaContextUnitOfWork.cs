using BM.GestaoProblema.Domain.Contracts.UnitsOfWork;
using BM.GestaoProblema.Infra.Data.Contexts;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Infra.Data.UnitsOfWork
{
    //Unidade de trabalho responsável pela conexão GestaoProblemaContext.
    public sealed class GestaoProblemaContextUnitOfWork
        : IGestaoProblemaContextUnitOfWork
    {
        //Variáveis para representação da injeção de dependência.
        private GestaoProblemaContext _context;

        public void Begin()
        {
            //Injeção de dependência via ServiceLocator.
            //O ServiceLocator será integrado com o framework de IoC,
            // onde iremos recuperar a instância do objeto.
            //Este objeto deve ser registrado no IoC de acordo com o tipo de projeto,
            // por exemplo, se for em um projeto web, o mesmo deverá retornar apenas 1 instância
            // por processamento (requisição)
            //Repasse da injeção.
            _context = ServiceLocator.Current.GetInstance<GestaoProblemaContext>();
        }

        public void SaveChanges()
        {
            //SaveChanges do contexto GestaoProblemaContext.
            _context.SaveChanges();
        }

        public void Dispose()
        {
            //Dispose do contexto GestaoProblemaContext.
            _context.Dispose();
        }
    }
}
