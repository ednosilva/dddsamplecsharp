using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BM.Validations;

using GestaoProblema.Domain.ValueObjects;
using GestaoProblema.CrossCutting.Resources;

namespace GestaoProblema.Domain.Entities
{
    //Entidade de chamado
    public sealed class ChamadoEntity : Core.Entity<Guid>
    {
        //Construtor para o Entity Framework
        public ChamadoEntity() { }

        //Construtor informando o que é obrigatório para o chamado existir.
        public ChamadoEntity(SistemaEntity sistema, ChamadoPrioridadeValueObject prioridade)
        {
            //Validação de negócio com o framework BM.Validations.
            ValidatorHelper.GarantirNaoNulo(sistema, Mensagens.ChamadoSistemaInvalido);

            //Set das propriedades:
            Codigo = new Guid();
            Sistema = sistema;
            CodigoSistema = sistema.Codigo;
            Prioridade = prioridade;
            //Status inicial
            Status = ChamadoStatusValueObject.Aberto;
            //Definição do prazo
            PrazoSolucao = new ChamadoPrazoSolucaoValueObject(prioridade);
        }

        //As propriedades estão como private set, pois apenas a própria classe
        // pode controlar as suas características.
        //Algumas propriedades são do tipo struct, então é necessário conter
        // o ? ou o Nullable<> para informar que a variável pode ser nula.
        public DateTime? DataInicioAtendimento { get; private set; }
        public DateTime? DataFinalizado { get; private set; }

        public int? CodigoAnalistaEmAtendimento { get; private set; }
        public AnalistaEntity AnalistaEmAtendimento { get; private set; }

        public int CodigoSistema { get; private set; }
        public SistemaEntity Sistema { get; private set; }
        public ChamadoStatusValueObject Status { get; private set; }
        public ChamadoPrioridadeValueObject Prioridade { get; private set; }
        public ChamadoPrazoSolucaoValueObject PrazoSolucao { get; private set; }

        //Funcionalidade do chamado para ser tratado por um analista
        public void ColocarEmAtendimento(AnalistaEntity analista)
        {
            //Validação de negócio com o framework BM.Validations.
            //Apenas chamados Em Aberto que podem ser atendidos:
            ValidatorHelper.GarantirVerdadeiro(Status == ChamadoStatusValueObject.Aberto, Mensagens.ChamadoJaFinalizadoOuEmAtendimentoPorUmAnalista);
            ValidatorHelper.GarantirNaoNulo(analista, Mensagens.ChamadoAnalistaEmAtendimentoInvalido);

            //Set das propriedades:
            AnalistaEmAtendimento = analista;
            CodigoAnalistaEmAtendimento = analista.Codigo;
            //Alteração do status (regra de negócio)
            Status = ChamadoStatusValueObject.EmAtendimento;
            //Definição da data (regra de negócio)
            DataInicioAtendimento = DateTime.Now;
        }

        //Funcionalidade do chamado para finalizar o chamado
        public void Finalizar()
        {
            //Validação de negócio com o framework BM.Validations.
            //Apenas chamados Em Atendimento que podem ser finalizados:
            ValidatorHelper.GarantirVerdadeiro(Status == ChamadoStatusValueObject.EmAtendimento, Mensagens.ChamadoNaoAtendido);

            //Alteração do status (regra de negócio)
            Status = ChamadoStatusValueObject.Fechado;

            //Definição da data (regra de negócio)
            DataFinalizado = DateTime.Now;
        }


        //Funcionalidade do ToString apenas para fins de registros
        public override string ToString()
        {
            switch (Status)
            {
                case ChamadoStatusValueObject.Aberto:
                    return string.Format(Mensagens.ChamadoAberto, DataCriacao, Sistema.Nome);
                case ChamadoStatusValueObject.EmAtendimento:
                    return string.Format(Mensagens.ChamadoEmAtendimento, DataInicioAtendimento.Value, AnalistaEmAtendimento.Nome);
                case ChamadoStatusValueObject.Fechado:
                    return string.Format(Mensagens.ChamadoFinalizado, DataFinalizado.Value, AnalistaEmAtendimento.Nome);
                default:
                    return "";
            }
        }
    }
}
