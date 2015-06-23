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
    // referente à cadastro, atualização e troca de time de suporte de um analista.
    public sealed class AnalistaDomainService
        : Contracts.Services.IAnalistaDomainService
    {
        //Variáveis para representação da injeção de dependência.
        private readonly Contracts.Repositories.IAnalistaRepository _analistaRepository;
        private readonly Contracts.Repositories.ITimeSuporteRepository _timeSuporteRepository;

        //Construtor informando as dependências necessárias para o funcionamento.
        public AnalistaDomainService(
            Contracts.Repositories.IAnalistaRepository analistaRepository,
            Contracts.Repositories.ITimeSuporteRepository timeSuporteRepository)
        {
            //Repasse da injeção.
            _analistaRepository = analistaRepository;
            _timeSuporteRepository = timeSuporteRepository;
        }

        //Cadastra um novo analista no sistema.
        public void Cadastrar(Entities.AnalistaEntity entity)
        {
            ValidarAnalista(entity);
            _analistaRepository.Add(entity);
        }

        //Atualiza um analista existente no sistema.
        public void Atualizar(Entities.AnalistaEntity entity)
        {
            ValidarAnalista(entity);
            _analistaRepository.Update(entity);
        }

        //Realiza a troca de time de um analista.
        public Entities.AnalistaEntity TrocarTimeSuporte(int codigo, int codigoTimeSuporte)
        {
            //Recupera o analista.
            var analista = _analistaRepository.GetByCodigo(codigo);

            //Valida se foi encontrado.
            ValidatorHelper.GarantirNaoNulo(analista, Mensagens.AnalistaNaoEncontrado);

            //Recupera o time de suporte.
            var timeSuporte = _timeSuporteRepository.GetByCodigo(codigo);

            //Valida se foi encontrado.
            ValidatorHelper.GarantirNaoNulo(timeSuporte, Mensagens.TimeSuporteNaoEncontrado);

            //Realiza a troca do time.
            analista.AlterarTimeSuporte(timeSuporte);

            //Atualiza na base de dados.
            _analistaRepository.Update(analista);

            return analista;
        }

        //Método comum de validação de um analista, evitando a replicação de código.
        private void ValidarAnalista(Entities.AnalistaEntity analista)
        {
            //Validação de negócio com BM.Validations.
            ValidatorHelper.GarantirNaoNulo(analista, Mensagens.AnalistaInvalido);
        }
    }
}
