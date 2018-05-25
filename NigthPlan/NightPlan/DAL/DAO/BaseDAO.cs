using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Model;

namespace DAL.DAO
{
    public class BaseDAO<T> : IBaseDAO<T> where T : class
    {
        private nightPlanContext context;

        public BaseDAO(nightPlanContext context)
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
