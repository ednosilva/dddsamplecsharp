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
    // referente à cadastro, atualização e troca de time de suporte de um sistema.
    public sealed class SistemaDomainService
        : Contracts.Services.ISistemaDomainService
    {
        //Variáveis para representação da injeção de dependência.
        private readonly Contracts.Repositories.ISistemaRepository _sistemaRepository;
        private readonly Contracts.Repositories.ITimeSuporteRepository _timeSuporteRepository;

        //Construtor informando as dependências necessárias para o funcionamento.
        public SistemaDomainService(
            Contracts.Repositories.ISistemaRepository sistemaRepository,
            Contracts.Repositories.ITimeSuporteRepository timeSuporteRepository)
        {
            //Repasse da injeção.
            _sistemaRepository = sistemaRepository;
            _timeSuporteRepository = timeSuporteRepository;
        }

        //Cadastra um novo sistema.
        public void Cadastrar(Entities.SistemaEntity entity)
        {
            GarantirSistemaValido(entity);
            _sistemaRepository.Add(entity);
        }

        //Atualiza um sistema existente.
        public void Atualizar(Entities.SistemaEntity entity)
        {
            GarantirSistemaValido(entity);
            _sistemaRepository.Update(entity);
        }

        //Realiza a troca de time de um sistema.
        public Entities.SistemaEntity TrocarTimeSuporte(int codigo, int codigoTimeSuporte)
        {
            //Recupera o sistema.
            var sistema = _sistemaRepository.GetByCodigo(codigo);

            //Valida se foi encontrado.
            ValidatorHelper.GarantirNaoNulo(sistema, Mensagens.SistemaNaoEncontrado);

            //Recupera o time de suporte.
            var timeSuporte = _timeSuporteRepository.GetByCodigo(codigo);

            //Valida se foi encontrado.
            ValidatorHelper.GarantirNaoNulo(timeSuporte, Mensagens.TimeSuporteNaoEncontrado);

            //Realiza a troca do time.
            sistema.AlterarTimeSuporte(timeSuporte);

            //Atualiza na base de dados.
            _sistemaRepository.Update(sistema);

            return sistema;
        }

        //Método comum de validação de um sistema, evitando a replicação de código.
        private void GarantirSistemaValido(Entities.SistemaEntity sistema)
        {
            //Validação de negócio com o framework BM.Validations.
            ValidatorHelper.GarantirNaoNulo(sistema, Mensagens.SistemaInvalido);
        }
    }
}
