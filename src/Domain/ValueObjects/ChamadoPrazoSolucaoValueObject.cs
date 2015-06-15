using GestaoProblema.CrossCutting.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProblema.Domain.ValueObjects
{
    //Objeto de valor prazo de solução que representa uma informação no chamado.
    public sealed class ChamadoPrazoSolucaoValueObject
    {
        //Construtor informando o que é obrigatório para o prazo de solução existir.
        public ChamadoPrazoSolucaoValueObject(ChamadoPrioridadeValueObject prioridade)
        {
            //Definição das horas de atendimento (regra de negócio)
            switch (prioridade)
            {
                case ChamadoPrioridadeValueObject.Normal:
                    //Set da propriedade
                    HorasUteis = 24;
                    break;
                case ChamadoPrioridadeValueObject.Crítico:
                    //Set da propriedade
                    HorasUteis = 4;
                    break;
                default:
                    throw new ApplicationException(Mensagens.ChamadoPrazoSolucaoPrioridadeNaoConfigurada);
            }

            //Set da propriedade
            Prioridade = prioridade;
        }

        //As propriedades estão como private set, pois apenas a própria classe
        // pode controlar as suas características.
        public ChamadoPrioridadeValueObject Prioridade { get; private set; }
        public int HorasUteis { get; private set; }
    }
}
