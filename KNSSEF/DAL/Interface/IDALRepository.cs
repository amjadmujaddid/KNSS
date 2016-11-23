using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNSSEF.DAL.Interface
{
    public interface IDALRepository<T> where T : class
    {
        /// <summary>
        /// Returns all entities
        /// </summary>
        /// <returns>List of entities</returns>
        List<T> GetAll();

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity">Entity Object</param>
        void Add(T entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity Object</param>
        void Update(T entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity Ojbect</param>
        void Delete(T entity);
    }
}
