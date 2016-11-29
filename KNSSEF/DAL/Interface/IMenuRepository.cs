using KNSSEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNSSEF.DAL.Interface
{
    public interface IMenuRepository : IDALRepository<Menu>
    {
        /// <summary>
        /// Get Data By Id Menu
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        Menu GetDataById(string menuId);
    }
}
