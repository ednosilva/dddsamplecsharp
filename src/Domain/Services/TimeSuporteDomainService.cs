using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BM.Validations;
using BM.GestaoProblema.Infra.CrossCutting.Resources;

namespace BM.GestaoProblema.Domain.Services
{
    //Serviço responsável pelas ações dos usuários
    // referente à cadastro e atualização de um time de suporte.
    public sealed class TimeSuporteDomainService
        : Contracts.Services.ITimeSuporteDomainService
    {
        //Variáveis para representação da injeção de dependência.
        private readonly Contracts.Repositories.ITimeSuporteRepository _timeSuporteRepository;

        //Construtor informando as dependências necessárias para o funcionamento.
        public TimeSuporteDomainService(
            Contracts.Repositories.ITimeSuporteRepository timeSuporteRepository)
        {
            //Repasse da injeção.
            _timeSuporteRepository = timeSuporteRepository;
        }

        //Cadastra um novo time de suporte.
        public void Cadastrar(Entities.TimeSuporteEntity entity)
        {
            GarantirTimeSuporteValido(entity);
            _timeSuporteRepository.Add(entity);
        }

        //Atualiza um time de suporte existente.
        public void Atualizar(Entities.TimeSuporteEntity entity)
        {
            GarantirTimeSuporteValido(entity);
            _timeSuporteRepository.Update(entity);
        }

        //Método comum de validação de um sistema, evitando a replicação de código.
        private void GarantirTimeSuporteValido(Entities.TimeSuporteEntity timeSuporte)
        {
            //Validação de negócio com o framework BM.Validations.
            ValidatorHelper.GarantirNaoNulo(timeSuporte, Mensagens.TimeSuporteInvalido);
        }
    }
}