using System.Collections.Generic;


namespace DAL.Interfaces
{
     public interface IBaseDAO<T> where T : class
    {
        /// <summary>
        /// Returns an enumerable collection of entities.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> List();

        /// <summary>
        /// Returns the only entity that satisfies a condition.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
       

        /// <summary>
        /// Update a given entity.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
    }
}