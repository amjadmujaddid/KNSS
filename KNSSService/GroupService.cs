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
                response.Messages.Add(ex.ToString());
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
                response.Messages.Add(ex.ToString());
            }

            return response;
        }

        public InsertDataGroupResponse InsertDataGroup(InsertDataGroupRequest request)
        {
            InsertDataGroupResponse response = new InsertDataGroupResponse();
            try
            {
                _groupRepo.Add(request.Group);
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.ToString());
            }
            return response;
        }

        public UpdateDataGroupResponse UpdateDataGroup(UpdateDataGroupRequest request)
        {
            UpdateDataGroupResponse response = new UpdateDataGroupResponse();
            try
            {
                _groupRepo.Update(request.Group);
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.ToString());
            }
            return response;
        }

        public DeleteDataGroupResponse DeleteDataGroup(DeleteDataGroupRequest request)
        {
            DeleteDataGroupResponse response = new DeleteDataGroupResponse();
            try
            {
                _groupRepo.Delete(request.Group);
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
