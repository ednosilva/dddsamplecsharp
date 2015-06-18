using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BM.Validations;
using BM.GestaoProblema.Domain.Collections;
using BM.GestaoProblema.Infra.CrossCutting.Resources;

namespace BM.GestaoProblema.Domain.Entities
{
    //Entidade de sistema
    public sealed class SistemaEntity : Core.Entity<int>
    {
        //Construtor para o Entity Framework
        public SistemaEntity() { }

        //Construtor informando o que é obrigatório para o analista existir.
        public SistemaEntity(string nome, TimeSuporteEntity timeSuporte)
        {
            //Validação de negócio com o framework BM.Validations.
            ValidatorHelper.GarantirValorPreenchido(nome, Mensagens.SistemaNomeInvalido);
            ValidatorHelper.GarantirNaoNulo(timeSuporte, Mensagens.SistemaTimeSuporteInvalido);

            //Set das propriedades:
            Nome = nome;
            TimeSuporte = timeSuporte;
            CodigoTimeSuporte = timeSuporte.Codigo;
        }

        //As propriedades estão como private set, pois apenas a própria classe
        // pode controlar as suas características.
        public string Nome { get; private set; }

        public int CodigoTimeSuporte { get; private set; }
        public TimeSuporteEntity TimeSuporte { get; private set; }
    }
}
