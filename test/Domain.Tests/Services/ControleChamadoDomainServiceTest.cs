using GestaoProblema.Domain.Contracts.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using GestaoProblema.Domain.Contracts.Repositories;
using GestaoProblema.Domain.Services;
using GestaoProblema.Domain.Entities;
using GestaoProblema.Domain.ValueObjects;
using System.Diagnostics;

namespace GestaoProblema.Domain.Tests.Services
{
    //Teste do controle de chamados
    [TestClass]
    public sealed class ControleChamadoDomainServiceTest
    {
        private Mock<ISistemaRepository> _sistemaRepositoryMock;
        private Mock<IChamadoRepository> _chamadoRepositoryMock;
        private Mock<IAnalistaRepository> _analistaRepositoryMock;

        private IControleChamadoDomainService _domainService;

        private SistemaEntity _sistema;
        private ChamadoEntity _chamado;
        private AnalistaEntity _analista;

        [TestInitialize]
        public void Initialize()
        {
            _sistemaRepositoryMock = new Mock<ISistemaRepository>();
            _chamadoRepositoryMock = new Mock<IChamadoRepository>();
            _analistaRepositoryMock = new Mock<IAnalistaRepository>();

            _domainService =
                new ControleChamadoDomainService(
                    _sistemaRepositoryMock.Object,
                    _chamadoRepositoryMock.Object,
                    _analistaRepositoryMock.Object);

            TimeSuporteEntity timeSuporte = new TimeSuporteEntity("Nome Time Suporte", "Descrição Time Suporte");
            _sistema = new SistemaEntity("Nome do Sistema", timeSuporte);
            _chamado = new ChamadoEntity(_sistema, ChamadoPrioridadeValueObject.Normal);
            _analista = new AnalistaEntity("Nome do analista", timeSuporte);
        }

        [TestMethod]
        public void QuandoEuAbrirUmChamado()
        {
            //arrange
            const int codigoSistema = 1;
            const ChamadoPrioridadeValueObject prioridade = ChamadoPrioridadeValueObject.Normal;

            _sistemaRepositoryMock.Setup(x => x.GetByCodigo(codigoSistema)).Returns(_sistema);

            ChamadoEntity chamado;

            //act
            chamado = _domainService.Abrir(codigoSistema, prioridade);

            //assert
            Assert.IsNotNull(chamado);
            Assert.AreEqual(DateTime.Now.Date, chamado.DataCriacao.Date);
            Assert.AreEqual(ChamadoStatusValueObject.Aberto, chamado.Status);
            Assert.AreEqual(ChamadoPrioridadeValueObject.Normal, chamado.Prioridade);

            Debug.WriteLine(chamado);
        }

        [TestMethod]
        public void QuandoEuColocarOChamadoEmAtendimento()
        {
            //arrange
            Guid codigoChamado = new Guid();
            const int codigoAnalista = 1;

            Debug.WriteLine(_chamado);
            _chamadoRepositoryMock.Setup(x => x.GetByCodigo(codigoChamado)).Returns(_chamado);
            _analistaRepositoryMock.Setup(x => x.GetByCodigo(codigoAnalista)).Returns(_analista);

            ChamadoEntity chamado;

            //act
            chamado = _domainService.ColocarEmAtendimento(codigoChamado, codigoAnalista);

            //assert
            Assert.AreEqual(ChamadoStatusValueObject.EmAtendimento, chamado.Status);
            Assert.AreEqual(_analista, chamado.AnalistaEmAtendimento);
            Assert.AreEqual(DateTime.Now.Date, chamado.DataInicioAtendimento.Value.Date);

            Debug.WriteLine(chamado);
        }

        [TestMethod]
        public void QuandoEuFinalizarUmChamado()
        {
            //arrange
            Guid codigoChamado = new Guid();

            Debug.WriteLine(_chamado);
            _chamado.ColocarEmAtendimento(_analista);
            Debug.WriteLine(_chamado);
            _chamadoRepositoryMock.Setup(x => x.GetByCodigo(codigoChamado)).Returns(_chamado);

            ChamadoEntity chamado;

            //act
            chamado = _domainService.Finalizar(codigoChamado);

            //assert
            Assert.AreEqual(ChamadoStatusValueObject.Fechado, chamado.Status);
            Assert.AreEqual(DateTime.Now.Date, chamado.DataFinalizado.Value.Date);

            Debug.WriteLine(chamado);
        }
    }
}
