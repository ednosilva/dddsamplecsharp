using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.GestaoProblema.Infra.Data.Extensions
{
    //Extensão do DbContext.
    //Adição de novas funcionalidades.
    public static class DbContextExtension
    {
        //Adiciona o método Update, onde facilitará a inclusão do objeto
        // no contexto e troca do EntityState para modified.
        public static void Update<TEntity>(this DbContext context, TEntity entity)
            where TEntity : class
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
