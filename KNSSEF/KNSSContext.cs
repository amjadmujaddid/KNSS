using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNSSEF
{
    public class KNSSContext<T> : DbContext where T : class
    {
        public KNSSContext()
            : base("name=KNSSEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        private DbSet<T> _dbEntities;

        /// <summary>
        /// Entities contained by this repository.
        /// </summary>        
        public DbSet<T> DBEntities
        {
            get { return _dbEntities ?? (_dbEntities = this.Set<T>()); }
        }
    }
}
