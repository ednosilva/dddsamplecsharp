using BM.GestaoProblema.Domain.Contracts.Repositories;
using BM.GestaoProblema.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BM.GestaoProblema.Application.Converters;
using BM.GestaoProblema.Domain.Entities;

namespace BM.GestaoProblema.Application.Services
{
    //Serviço de aplicação.
    //Simplificação da utilização das funcionalidades de Analista.
    public sealed class AnalistaApplicationService
        : Core.BaseApplicationService
        , Contracts.IAnalistaApplicationService
    {
        //Variáveis para representação da injeção de dependência.
        private readonly IAnalistaRepository _analistaRepository;
        private readonly IAnalistaDomainService _analistaDomainService;
        private readonly ITimeSuporteRepository _timeSuporteRepository;

        //Construtor informando as dependências necessárias para o funcionamento.
        public AnalistaApplicationService(
            IAnalistaRepository analistaRepository,
            IAnalistaDomainService analistaDomainService,
            ITimeSuporteRepository timeSuporteRepository)
        {
            //Repasse da injeção.
            _analistaRepository = analistaRepository;
            _analistaDomainService = analistaDomainService;
            _timeSuporteRepository = timeSuporteRepository;
        }

        //Método simplificado de uma consulta por código.
        public Dtos.AnalistaDto ConsultarPorCodigo(int codigoAnalista)
        {
            //Consulta a entidade.
            var entity =
                _analistaRepository.GetByCodigo(codigoAnalista);

            //Converte a entidade para Dto.
            return entity.ToDto();
        }

        //Método simplificado de um cadastro de um analista.
        public Dtos.AnalistaDto Cadastrar(string nome, int codigoTimeSuporte)
        {
            //Inicia o processo de UnitOfWork
            Begin();

            //Executa o serviço de cadastrar um analista.
            var entity = _analistaDomainService.Cadastrar(nome, codigoTimeSuporte);

            //Finaliza o processo do UnitOfWork.
            SaveChanges();

            //Converte a entidade para Dto.
            return entity.ToDto();
        }

        //Método simplificado de uma troca de time de suporte de um analista.
        public Dtos.AnalistaDto TrocarTimeSuporte(int codigoAnalista, int codigoTimeSuporte)
        {
            //Consulta a entidade.
            var entity =
                _analistaDomainService.TrocarTimeSuporte(codigoAnalista, codigoTimeSuporte);

            //Converte a entidade para Dto.
            return entity.ToDto();
        }

        //Método simplificado de uma atualização de um analista.
        public void Atualizar(Dtos.AnalistaDto dto)
        {
            //Consulta a entidade.
            var entity =
                _analistaRepository.GetByCodigo(dto.Codigo);

            //Consulta o time de suporte.
            var timeSuporteEntity =
                _timeSuporteRepository.GetByCodigo(dto.CodigoTimeSuporte);

            //Executa as alterações.
            entity.AlterarNome(dto.Nome);
            entity.AlterarTimeSuporte(timeSuporteEntity);

            //Inicia o processo de UnitOfWork
            Begin();

            //Executa o serviço de atualizar um analista.
            _analistaDomainService.Atualizar(entity);

            //Finaliza o processo do UnitOfWork.
            SaveChanges();
        }

        
    }
}
