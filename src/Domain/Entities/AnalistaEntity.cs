using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BM.Validations;
using BM.GestaoProblema.Infra.CrossCutting.Resources;

namespace BM.GestaoProblema.Domain.Entities
{
    //Entidade de analista
    public sealed class AnalistaEntity : Core.Entity<int>
    {
        //Construtor para o Entity Framework
        private AnalistaEntity() { }

        //Construtor informando o que é obrigatório para o analista existir.
        public AnalistaEntity(string nome, TimeSuporteEntity timeSuporte)
        {
            //Validação e sets das propriedades.
            AlterarNome(nome);
            AlterarTimeSuporte(timeSuporte);
        }

        //As propriedades estão como private set, pois apenas a própria classe
        // pode controlar as suas características.
        public string Nome { get; private set; }

        public int CodigoTimeSuporte { get; private set; }
        public TimeSuporteEntity TimeSuporte { get; private set; }

        //Funcionalidade de realizar a troca de um time de suporte.
        public void AlterarTimeSuporte(TimeSuporteEntity timeSuporte)
        {
            //Validação de negócio com o framework BM.Validations.
            ValidatorHelper.GarantirNaoNulo(timeSuporte, Mensagens.AnalistaTimeSuporteInvalido);

            //Set das propriedades:
            TimeSuporte = timeSuporte;
            CodigoTimeSuporte = timeSuporte.Codigo;
        }

        public void AlterarNome(string nome)
        {
            //Validação de negócio com o framework BM.Validations.
            ValidatorHelper.GarantirValorPreenchido(nome, Mensagens.AnalistaNomeInvalido);

            //Set das propriedades:
            Nome = nome;
        }
    }
}
