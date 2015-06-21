using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Entities.Core
{
    //Classe base para as entidades.
    //Para transformar uma classe em entidade, basta herdá-la.
    //Foi limitado o tipo do código para apenas tipos structs (int, string, DateTime, Guid e etc).
    //A classe foi criada como abstrata para apenas herdá-la.
    public abstract class Entity<T>
        where T : struct
    {
        public Entity()
        {
            //Foi definido a data que foi criado o objeto.
            DataCriacao = DateTime.Now;
        }

        //Foi criado um código para dar uma identificação para a identidade.
        //Foi colocado como virtual para sobrescrevê-lo e colocar DataAnotations se necessário.
        public virtual T Codigo { get; protected set; }

        //Foi criado uma data de criação desse objeto.
        public DateTime DataCriacao { get; protected set; }
    }
}
