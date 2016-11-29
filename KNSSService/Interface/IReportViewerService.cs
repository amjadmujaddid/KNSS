using KNSSEF.Model;
using KNSSService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNSSService.Interface
{
    #region Service Definition

    public interface IReportViewerService
    {
        /// <summary>
        /// Get All Data ReportViewer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetAllDataReportViewerResponse GetAllDataReportViewer();

        /// <summary>
        /// Get Data ReportViewer By Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetDataReportViewerByIdResponse GetDataReportViewerById(GetDataReportViewerByIdRequest request);

    }

    #endregion

    #region Message

    public class GetAllDataReportViewerRequest
    {

    }

    public class GetAllDataReportViewerResponse : ResponseBase
    {
        private List<Group> _ReportViewerList;

        public List<Group> ReportViewerList
        {
            get { return _ReportViewerList ?? (_ReportViewerList = new List<Group>()); }
        }
    }

    public class GetDataReportViewerByIdRequest
    {
        public string ReportViewerId { get; set; }
    }

    public class GetDataReportViewerByIdResponse : ResponseBase
    {
        public Group ReportViewer { get; set; }
    }
    #endregion
}
