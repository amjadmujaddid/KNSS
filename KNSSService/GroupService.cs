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
    public class GroupService : IGroupService
    {
        #region Attribute Class

        IGroupRepository _groupRepo;

        #endregion

        #region Constructor

        public GroupService()
        {
            _groupRepo = new GroupRepository();
        }

        #endregion

        #region IGroupService Implementation

        public GetAllDataGroupResponse GetAllDataGroup()
        {
            GetAllDataGroupResponse response = new GetAllDataGroupResponse();
            try
            {
                List<Group> _listGroup = _groupRepo.GetAll();
                response.GroupList.AddRange(_listGroup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return response;
        }

        public GetDataGroupByIdResponse GetDataGroupById(GetDataGroupByIdRequest request)
        {
            GetDataGroupByIdResponse response = new GetDataGroupByIdResponse();
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                {
                    response.Group = _groupRepo.GetDataById(request.groupId);
                    transScope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return response;
        }

        public InsertDataGroupResponse InsertDataGroup(InsertDataGroupRequest request)
        {
            InsertDataGroupResponse response = new InsertDataGroupResponse();
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                {
                    _groupRepo.Add(request.Group);
                    transScope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return response;
        }

        public UpdateDataGroupResponse UpdateDataGroup(UpdateDataGroupRequest request)
        {
            UpdateDataGroupResponse response = new UpdateDataGroupResponse();
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                {
                    _groupRepo.Update(request.Group);
                    transScope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return response;
        }

        #endregion
    }
}
