using KNSSEF.DAL;
using KNSSEF.DAL.Interface;
using KNSSEF.Model;
using KNSSService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace KNSSService
{
    public class MenuService : IMenuService
    {
        #region Attribute Class

        IMenuRepository _menuRepo;

        #endregion

        #region Constructor

        public MenuService()
        {
            _menuRepo = new MenuRepository();
        }

        #endregion

        #region IMenuService Implementation

        public GetAllDataMenuResponse GetAllDataMenu()
        {
            GetAllDataMenuResponse response = new GetAllDataMenuResponse();
            try
            {
                List<Menu> _listMenu = _menuRepo.GetAll();
                response.GroupList.AddRange(_listMenu);
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.ToString());
            }

            return response;
        }

        public GetDataMenuByIdResponse GetDataMenuById(GetDataMenuByIdRequest request)
        {
            GetDataMenuByIdResponse response = new GetDataMenuByIdResponse();
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                {
                    response.Menu = _menuRepo.GetDataById(request.menuId);
                    transScope.Complete();
                }
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.ToString());
            }

            return response;
        }

        public InsertDataMenuResponse InsertDataMenu(InsertDataMenuRequest request)
        {
            InsertDataMenuResponse response = new InsertDataMenuResponse();
            try
            {
                _menuRepo.Add(request.Menu);
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.ToString());
            }

            return response;
        }

        public UpdateDataMenuResponse UpdateDataMenu(UpdateDataMenuRequest request)
        {
            UpdateDataMenuResponse response = new UpdateDataMenuResponse();
            try
            {
                _menuRepo.Update(request.Menu);
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.ToString());
            }

            return response;
        }

        public DeleteDataMenuResponse DeleteDataMenu(DeleteDataMenuRequest request)
        {
            DeleteDataMenuResponse response = new DeleteDataMenuResponse();
            try
            {
                _menuRepo.Delete(request.Menu);
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.ToString());
            }

            return response;
        }

        #endregion
    }
}
