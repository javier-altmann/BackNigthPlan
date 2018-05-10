using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Model;

namespace DAL.DAO
{
    public class BaseDAO<T> : IBaseDAO<T> where T : class
    {
        private nigthPlanContext context;

        public BaseDAO(nigthPlanContext context)
        {
            this.context = context;
            
        }

        public IEnumerable<T> List()
        {
            return context.Set<T>();
        }


        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}
