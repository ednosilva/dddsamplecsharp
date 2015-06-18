using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Domain.Collections.Core
{
    /*
     * Foi criada uma base para as coleções, 
     *  para não ter que ficar replicando código.
     * Agora basta criar uma classe e para transformá-la
     *  em uma coleção, basta herdá-la.
     * Precisamos ter controle dos métodos Add, Remove e Clear,
     *  pois são os métodos que possam passar por uma regra de negócio.
     *  Neste caso, colocamos como virtual, para poder ser alterado.
     * Utilizamos o ICollection<T>, pois ele é a menor coleção
     *  que o EntityFramework aceita.
     */
    public abstract class BaseCollection<T>
        : ICollection<T>
    {
        //Variável de nível de classe e herança
        protected readonly ICollection<T> Collection;

        #region Construtores

        //Instância default
        protected BaseCollection()
        {
            Collection = new Collection<T>();
        }

        //Instância a partir de uma lista, podendo assim ter uma conversão 
        // mais prática
        protected BaseCollection(IList<T> list)
        {
            Collection = new Collection<T>(list);
        }
        #endregion

        #region Propriedades Comuns
        //Propriedades que normalmente não contém uma regra de negócio.

        public int Count
        {
            get { return Collection.Count; }
        }
        public bool IsReadOnly
        {
            get { return Collection.IsReadOnly; }
        } 
        #endregion

        #region Métodos Virtuais
        //Método de adicionar convencional, porém com 
        // a opção de ser sobrescrito.
        public virtual void Add(T item)
        {
            Collection.Add(item);
        }

        //Método de adicionar convencional, porém com 
        // a opção de ser sobrescrito.
        public virtual bool Remove(T item)
        {
            return Collection.Remove(item);
        }

        //Método de adicionar convencional, porém com 
        // a opção de ser sobrescrito.
        public virtual void Clear()
        {
            Collection.Clear();
        }
        #endregion

        #region Métodos Customizados
        //Método para adicionar vários itens de uma vez.
        public void AddRange(IEnumerable<T> itens)
        {
            foreach (var item in itens)
                Add(item);
        }
        #endregion

        #region Métodos Comuns
        //Métodos que normalmente não contém uma regra de negócio.

        public bool Contains(T item)
        {
            return Collection.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            Collection.CopyTo(array, arrayIndex);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
