using BM.GestaoProblema.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Application.Contracts
{
    //Contrato de serviço de aplicação.
    //Simplificação da utilização das funcionalidades de Analista.
    public interface IAnalistaApplicationService
    {
        AnalistaDto ConsultarPorCodigo(int codigoAnalista);
        AnalistaDto Cadastrar(string nome, int codigoTimeSuporte);
        AnalistaDto TrocarTimeSuporte(int codigoAnalista, int codigoTimeSuporte);
        void Atualizar(AnalistaDto dto);
    }
}
