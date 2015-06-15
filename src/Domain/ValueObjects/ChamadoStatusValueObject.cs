using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProblema.Domain.ValueObjects
{
    //Objeto de valor status que representa uma informação no chamado.
    public enum ChamadoStatusValueObject
    {
        Aberto = 1,
        EmAtendimento = 2,
        Fechado = 3
    }
}
