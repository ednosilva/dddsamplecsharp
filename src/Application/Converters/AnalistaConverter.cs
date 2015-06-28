using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BM.GestaoProblema.Application.Dtos;
using BM.GestaoProblema.Domain.Entities;

namespace BM.GestaoProblema.Application.Converters
{
    public static class AnalistaConverter
    {
        public static AnalistaDto ToDto(this AnalistaEntity entity)
        {
            return entity == null
                ? null
                : new AnalistaDto
                {
                    Codigo = entity.Codigo,
                    CodigoTimeSuporte = entity.CodigoTimeSuporte,
                    DataCriacao = entity.DataCriacao,
                    Nome = entity.Nome
                };
        }
    }
}
