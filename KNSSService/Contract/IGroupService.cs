using KNSSEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNSSService.Contract
{
    #region Service Definition

    public interface IGroupService
    {
        /// <summary>
        /// Get All Data Group
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetAllDataGroupResponse GetAllDataGroup();

        /// <summary>
        /// Get Data Group By Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetDataGroupByIdResponse GetDataGroupById(GetDataGroupByIdRequest request);

        /// <summary>
        /// Insert Data Group
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        InsertDataGroupResponse InsertDataGroup(InsertDataGroupRequest request);

        /// <summary>
        /// Update Data Group
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateDataGroupResponse UpdateDataGroup(UpdateDataGroupRequest request);

    }

    #endregion

    #region Message

    public class GetAllDataGroupRequest
    {

    }

    public class GetAllDataGroupResponse : ResponseBase
    {
        private List<Group> _groupList;

        public List<Group> GroupList
        {
            get { return _groupList ?? (_groupList = new List<Group>()); }
        }
    }

    public class GetDataGroupByIdRequest
    {
        public string groupId { get; set; }
    }

    public class GetDataGroupByIdResponse : ResponseBase
    {
        public Group Group { get; set; }
    }

    public class InsertDataGroupRequest
    {
        public Group Group { get; set; }
    }

    public class InsertDataGroupResponse : ResponseBase
    {

    }

    public class UpdateDataGroupRequest
    {
        public Group Group { get; set; }
    }

    public class UpdateDataGroupResponse : ResponseBase
    {
        public Group Group { get; set; }
    }

    #endregion
}
