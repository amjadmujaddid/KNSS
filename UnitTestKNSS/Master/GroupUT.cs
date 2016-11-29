using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KNSSService.Contract;
using KNSSService;
using KNSSEF.Model;

namespace UnitTestKNSS.Master
{
    [TestClass]
    public class GroupUT
    {
        #region Class Attribute and Property

        private IGroupService _groupService = new GroupService();

        #endregion

        #region TestData

        Group _groupValidData = new Group()
        {
            GroupId = "0001",
            GroupName = "Developer",
            CreateBy = "101",
            CreateDate = DateTime.Now,
            EditBy = "101",
            EditDate = DateTime.Now
        };

        Group _groupUpdateData = new Group()
        {
            GroupId = "0001",
            GroupName = "Developer Update",
            EditBy = "202",
            EditDate = DateTime.Now
        };

        Group _groupGetDataById = new Group()
        {
            GroupId = "0001"
        };

        Group _groupDeleteData = new Group()
        {
            GroupId = "0001"
        };

        Group _groupGetDataByFilter = new Group()
        {
            GroupId = "0001",
            GroupName = "Dev"
        };

        #endregion

        #region Test Method

        [TestMethod]
        public void InsertDataGroupTest()
        {
            InsertDataGroupRequest request = new InsertDataGroupRequest();
            request.Group = _groupValidData;
            InsertDataGroupResponse response = _groupService.InsertDataGroup(request);

            Assert.IsTrue(response.Messages.Count == 0, "Failed insert data");
        }

        [TestMethod]
        public void UpdateDataGroupTest()
        {
            UpdateDataGroupRequest request = new UpdateDataGroupRequest();
            request.Group = _groupUpdateData;
            UpdateDataGroupResponse response = _groupService.UpdateDataGroup(request);

            Assert.IsTrue(response.Messages.Count == 0, "Failed update data");
        }

        [TestMethod]
        public void GetDataGroupByIdTest()
        {
            GetDataGroupByIdRequest request = new GetDataGroupByIdRequest();
            request.groupId = _groupGetDataById.GroupId;
            GetDataGroupByIdResponse response = _groupService.GetDataGroupById(request);

            Assert.IsTrue(response.Messages.Count == 0, "Failed get data by Id");
        }

        [TestMethod]
        public void GetAllDataGroup()
        {
            GetAllDataGroupResponse response = _groupService.GetAllDataGroup();

            Assert.IsTrue(response.Messages.Count == 0, "Failed get all data");
        }

        [TestMethod]
        public void DeleteDataGroup()
        {
            GetDataGroupByIdRequest getRequest = new GetDataGroupByIdRequest();
            getRequest.groupId = _groupGetDataById.GroupId;

            GetDataGroupByIdResponse getResponse = _groupService.GetDataGroupById(getRequest);

            if (getResponse.Messages.Count != 0)
            {
                throw new Exception("Delete failed!");
            }
            else
            {
                DeleteDataGroupRequest request = new DeleteDataGroupRequest();

                request.Group = getResponse.Group;
                DeleteDataGroupResponse response = _groupService.DeleteDataGroup(request);
            }
        }

        [TestMethod]
        public void GetDataGroupByFilterTest()
        {
            GetDataGroupByFilterRequest request = new GetDataGroupByFilterRequest();
            request.groupId = _groupGetDataByFilter.GroupId;
            request.groupName = _groupGetDataByFilter.GroupName;
            GetDataGroupByFilterResponse response = _groupService.GetDataGroupByFilter(request);

            Assert.IsTrue(response.Messages.Count == 0, "Failed get data by Filter");

        }
        #endregion
    }
}
