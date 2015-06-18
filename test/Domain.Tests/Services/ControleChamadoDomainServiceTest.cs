using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using BM.GestaoProblema.Domain.Contracts.Services;
using BM.GestaoProblema.Domain.Contracts.Repositories;
using BM.GestaoProblema.Domain.Services;
using BM.GestaoProblema.Domain.Entities;
using BM.GestaoProblema.Domain.ValueObjects;
using System.Diagnostics;

namespace BM.GestaoProblema.Domain.Tests.Services
{
    //Teste do controle de chamados.
    //TestClass serve para informar que a classe faz a execução de testes.
    [TestClass]
    public sealed class ControleChamadoDomainServiceTest
    {
        //Classes mocadas pelo framework MoQ.
        //O mock de um objeto é uma simulação. Você pode programá-lo
        // para simular um resulado.
        private Mock<ISistemaRepository> _sistemaRepositoryMock;
        private Mock<IChamadoRepository> _chamadoRepositoryMock;
        private Mock<IAnalistaRepository> _analistaRepositoryMock;

        //Serviço de Controle de Chamado.
        //Variáves utilizada para a execução dos testes.
        //Como o serviço não mantém estado, podemos deixar uma 
        // variável de nível de classe com uma instância para
        // a reutilização da mesma.
        private IControleChamadoDomainService _domainService;

        //Objetos para suporte nos mocks.
        private SistemaEntity _sistema;
        private ChamadoEntity _chamado;
        private AnalistaEntity _analista;

        //O TestInitialize é executado toda vez
        // antes de executar o teste.
        //Ele será o responsável para iniciar as variáveis de suporte
        // e os mocks comuns nos testes.
        [TestInitialize]
        public void Initialize()
        {
            //Instância dos mocks
            _sistemaRepositoryMock = new Mock<ISistemaRepository>();
            _chamadoRepositoryMock = new Mock<IChamadoRepository>();
            _analistaRepositoryMock = new Mock<IAnalistaRepository>();

            //Intância normal do serviço.
            //Está sendo utilizado o "...Mock.Object", que 
            // é a intância simulada do objeto.
            _domainService =
                new ControleChamadoDomainService(
                    _sistemaRepositoryMock.Object,
                    _chamadoRepositoryMock.Object,
                    _analistaRepositoryMock.Object);

            //Instâncias de objetos para suporte nos mocks.
            TimeSuporteEntity timeSuporte = new TimeSuporteEntity("Nome Time Suporte", "Descrição Time Suporte");
            _sistema = new SistemaEntity("Nome do Sistema", timeSuporte);
            _chamado = new ChamadoEntity(_sistema, ChamadoPrioridadeValueObject.Normal);
            _analista = new AnalistaEntity("Nome do analista", timeSuporte);
        }

        /* Utilizamos o pattern Arrange-Act-Assert (AAA),
         *  para mantermos uma organização melhor dos nossos testes, onde:
         *  
         * arrange: Preparação dos objetos necessários para os testes.
         * act:     Execução da funcionalidade que será testada.
         * assert:  Garantia do resultado da funcionalidade.
         */

        //TestMethod serve para transformar o método em um método de teste.
        //Este teste consiste em garantir uma saída correta para a abertura de chamado. (variável do tipo ChamadoEntity)
        [TestMethod]
        public void QuandoEuAbrirUmChamado()
        {
            //arrange: 
            // Definimos um código de sistema fictício.
            const int codigoSistema = 1;

            //Definimos uma prioridade.
            const ChamadoPrioridadeValueObject prioridade = ChamadoPrioridadeValueObject.Normal;

            //Definimos o que o repositório irá retornar de acordo com o código informado.
            _sistemaRepositoryMock.Setup(x => x.GetByCodigo(codigoSistema)).Returns(_sistema);

            //Declaramos a variável de retorno do teste.
            ChamadoEntity chamado;

            //act
            //Executamos a funcionalidade que será testada.
            chamado = _domainService.Abrir(codigoSistema, prioridade);

            //assert
            //Garantimos que o resultado da funcionalidade seja o esperado.

            //Garantimos que a variável de retorno não seja nula.
            Assert.IsNotNull(chamado);

            //Garantimos que a data da criação é a mesma de hoje. 
            // *Não foi validado a hora, pois pode ocorrer diferença de milésimos de segundos.
            Assert.AreEqual(DateTime.Now.Date, chamado.DataCriacao.Date);

            //Garantimos que o status do chamado seja Aberto, quando ele for criado.
            Assert.AreEqual(ChamadoStatusValueObject.Aberto, chamado.Status);

            //Garantimos que a prioridade do chamado seja a mesma que solicitamos.
            Assert.AreEqual(ChamadoPrioridadeValueObject.Normal, chamado.Prioridade);

            //O resultado do chamado será escrito no Output. (serve apenas fins de log do teste)
            //Debug.WriteLine está fazendo um chamado.ToString() com a variável chamado.
            //O método ToString foi sobrescrito, informando os dados daquele chamado.
            Debug.WriteLine(chamado);
        }

        //Este teste consiste em garantir uma saída correta para a alteração de chamado para em atendimento.
        [TestMethod]
        public void QuandoEuColocarOChamadoEmAtendimento()
        {
            //arrange
            //Definimos um código de chamado fictício.
            Guid codigoChamado = new Guid();

            //Definimos um código de analista fictício.
            const int codigoAnalista = 1;

            //O _chamado é um chamado fictício.
            //Escrevemos no Output o resultado do _chamado para fins de logs.
            Debug.WriteLine(_chamado);

            //Definimos o que os repositórios irão retornar de acordo com os dados informados.
            _chamadoRepositoryMock.Setup(x => x.GetByCodigo(codigoChamado)).Returns(_chamado);
            _analistaRepositoryMock.Setup(x => x.GetByCodigo(codigoAnalista)).Returns(_analista);

            //Declaramos a variável de retorno do teste.
            ChamadoEntity chamado;

            //act
            //Executamos a funcionalidade que será testada.
            chamado = _domainService.ColocarEmAtendimento(codigoChamado, codigoAnalista);

            //assert
            //Garantimos que o resultado da funcionalidade seja o esperado.
            //Garantimos que o chamado retornado seja o mesmo que foi buscado pelo repositório.
            Assert.AreEqual(chamado, _chamado);

            //Garantirmos que o status do chamado foi alterado para EmAtendimento.
            Assert.AreEqual(ChamadoStatusValueObject.EmAtendimento, chamado.Status);

            //Garantimos que o analista foi definido de acordo com o informado.
            Assert.AreEqual(_analista, chamado.AnalistaEmAtendimento);

            //Garantimos que a data do início de atendimento foi informada.
            Assert.AreEqual(DateTime.Now.Date, chamado.DataInicioAtendimento.Value.Date);

            //Escrevemos no Output o resultado do chamado para fins de logs.
            Debug.WriteLine(chamado);
        }

        [TestMethod]
        public void QuandoEuFinalizarUmChamado()
        {
            //arrange
            //Definimos um código de analista fictício.
            Guid codigoChamado = new Guid();

            //Escrevemos no Output o resultado do _chamado para fins de logs.
            Debug.WriteLine(_chamado);

            //Definimos uma alteração para em atendimento de um chamado que estava com o status aberto.
            _chamado.ColocarEmAtendimento(_analista);

            //Escrevemos no Output o resultado do _chamado para fins de logs, pois foi alterado o status.
            Debug.WriteLine(_chamado);

            //Definimos o que os repositórios irão retornar de acordo com os dados informados.
            _chamadoRepositoryMock.Setup(x => x.GetByCodigo(codigoChamado)).Returns(_chamado);

            //Declaramos a variável de retorno do teste.
            ChamadoEntity chamado;

            //act
            //Executamos a funcionalidade que será testada.
            chamado = _domainService.Finalizar(codigoChamado);

            //assert
            //Garantimos que o resultado da funcionalidade seja o esperado.
            //Garantimos que o chamado retornado seja o mesmo que foi buscado pelo repositório.
            Assert.AreEqual(chamado, _chamado);

            //Garantirmos que o status do chamado foi alterado para fechado.
            Assert.AreEqual(ChamadoStatusValueObject.Fechado, chamado.Status);

            //Garantimos que a data, que o chamado foi finalizado, foi informada.
            Assert.AreEqual(DateTime.Now.Date, chamado.DataFinalizado.Value.Date);

            //Escrevemos no Output o resultado do chamado para fins de logs.
            Debug.WriteLine(chamado);
        }
    }
}
