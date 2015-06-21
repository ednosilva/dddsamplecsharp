using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BM.GestaoProblema.Infra.CrossCutting.IoC.Extensions;
using BM.GestaoProblema.Domain.Services;
using BM.GestaoProblema.Infra.Data.Contexts;
using BM.GestaoProblema.Infra.Data.Repositories;
using BM.GestaoProblema.Infra.Data.UnitsOfWork;

namespace BM.GestaoProblema.Infra.CrossCutting.IoC
{
    //O IoC Config controla os registros das 
    //interfaces/instâncias do nosso sistema.
    public static class IoCConfig
    {
        //O método Register adiciona as classes
        // necessárias para o sistema funcionar.
        //Utilizamos o Lifestyle para reutilizarmos o nosso IoC 
        // em vários "projetos finais", como Web, WebApi, WindowsForms e etc.
        //É importante saber sobre o Lifestyle, pois é ele que garante como
        // as instâncias deverão ser geradas, como por exemplo, na web. 
        // Se registrarmos como Trasient, o nosso UnitOfWork não irá funcionar,
        // pois ele depende de 1 instância única por request, caso contrário,
        // o unit of work vai se confundir sobre as intâncias.
        //Neste cenário, utilizamos apenas um método para registrar tudo, mas 
        // se for necessário controlar os lifestyles separadamente, basta
        // refatorá-los.
        public static void Register(Container container, Lifestyle lifestyle)
        {
            //Registra os contextos
            container.BatchRegister<GestaoProblemaContext>(lifestyle);

            //Registra os units of work
            container.BatchRegister<GestaoProblemaContextUnitOfWork>(lifestyle);

            //Registra os resitórios
            container.BatchRegister<AnalistaRepository>(lifestyle);

            //Registra os serviços de domínio
            container.BatchRegister<ControleChamadoDomainService>(lifestyle);

            //Registra os serviços de Application
            //container.BatchRegister<>(lifeStyle); //ainda não foi feito
        }
    }
}
