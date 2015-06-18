using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BM.Validations;
using BM.GestaoProblema.Infra.CrossCutting.Resources;
using BM.GestaoProblema.Domain.Collections;

namespace BM.GestaoProblema.Domain.Entities
{
    //Entidade de time de suporte
    public sealed class TimeSuporteEntity : Core.Entity<int>
    {
        //Construtor para o Entity Framework
        public TimeSuporteEntity() { }

        //Construtor informando o que é obrigatório para o analista existir.
        public TimeSuporteEntity(string nome, string descricao)
        {
            //Validação de negócio com o framework BM.Validations.
            ValidatorHelper.GarantirValorPreenchido(nome, Mensagens.TimeSuporteNomeInvalido);
            ValidatorHelper.GarantirValorPreenchido(descricao, Mensagens.TimeSuporteDescricaoInvalido);

            //Set das propriedades:
            Nome = nome;
            Descricao = descricao;

            //A lista sempre deve ter uma instância, pois ela deve
            // ser representada como zero ou mais itens.
            Analistas = new AnalistaCollection();
        }

        //As propriedades estão como private set, pois apenas a própria classe
        // pode controlar as suas características.
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public AnalistaCollection Analistas { get; private set; }
    }
}
