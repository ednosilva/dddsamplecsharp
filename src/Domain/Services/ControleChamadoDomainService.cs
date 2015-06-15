using GestaoProblema.Domain.Entities;
using GestaoProblema.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BM.Validations;
using GestaoProblema.Domain.Contracts.Repositories;
using GestaoProblema.CrossCutting.Resources;

namespace GestaoProblema.Domain.Services
{
    //Serviço responsável pelas ações dos usuários
    // referente à abertura, atendimento e finalização do chamado.
    public sealed class ControleChamadoDomainService : Contracts.Services.IControleChamadoDomainService
    {
        //Variáveis para representação da injeção de dependência.
        private readonly ISistemaRepository _sistemaRepository;
        private readonly IChamadoRepository _chamadoRepository;
        private readonly IAnalistaRepository _analistaRepository;

        //Construtor informando as dependências necessárias para trabalhar.
        public ControleChamadoDomainService(
            ISistemaRepository sistemaRepository,
            IChamadoRepository chamadoRepository,
            IAnalistaRepository analistaRepository)
        {
            //Repasse da injeção
            _sistemaRepository = sistemaRepository;
            _chamadoRepository = chamadoRepository;
            _analistaRepository = analistaRepository;
        }

        //Realização da abertura do chamado.
        public ChamadoEntity Abrir(int codigoSistema, ChamadoPrioridadeValueObject prioridade)
        {
            //Recupera o sitema:
            var sistema = _sistemaRepository.GetByCodigo(codigoSistema);
            //Valida se o mesmo existe:
            ValidatorHelper.GarantirNaoNulo(sistema, Mensagens.SistemaNaoEncontrado);

            //Cria o chamado:
            var chamado = new ChamadoEntity(sistema, prioridade);

            //Salva o chamado:
            _chamadoRepository.Add(chamado);

            //Retorna o chamado criado:
            return chamado;
        }

        //Realização do tratamento do chamado.
        public ChamadoEntity ColocarEmAtendimento(Guid codigoChamado, int codigoAnalista)
        {
            //Recupera o chamado:
            var chamado = _chamadoRepository.GetByCodigo(codigoChamado);
            
            //Valida se o mesmo existe:
            GarantirChamadoEncontrado(chamado);

            //Recupera o analista:
            var analista = _analistaRepository.GetByCodigo(codigoAnalista);

            //Valida se o mesmo existe:
            ValidatorHelper.GarantirNaoNulo(analista, Mensagens.AnalistaNaoEncontrado);

            //Chama a funcionalidade de colocar em atendimento do objeto:
            chamado.ColocarEmAtendimento(analista);

            //Salva as alterações do chamado:
            _chamadoRepository.Update(chamado);

            //Retorna o chamado tratado:
            return chamado;
        }

        //Realização do término do chamado.
        public ChamadoEntity Finalizar(Guid codigo)
        {
            //Recupera o chamado:
            var chamado = _chamadoRepository.GetByCodigo(codigo);

            //Valida se o mesmo existe:
            GarantirChamadoEncontrado(chamado);

            //Chama a funcionalidade de finalizar o chamado:
            chamado.Finalizar();

            //Salva as alterações do chamado:
            _chamadoRepository.Update(chamado);

            //Retorna o chamado finalizado:
            return chamado;
        }

        //Valida se o chamado não é nulo
        private void GarantirChamadoEncontrado(ChamadoEntity chamado)
        {
            //Validação de negócio com o framework BM.Validations.
            ValidatorHelper.GarantirNaoNulo(chamado, Mensagens.ChamadoNaoEncontrado);
        }
    }
}
