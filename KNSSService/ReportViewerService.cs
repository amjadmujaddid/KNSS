using KNSSEF.DAL;
using KNSSEF.DAL.Interface;
using KNSSEF.Model;
using KNSSService.Contract;
using KNSSService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace KNSSService
{
    public class ReportViewerService : IReportViewerService
    {
        #region Attribute Class

        IReportViewerRepository _reportViewerRepo;

        #endregion

        #region Constructor

        public ReportViewerService()
        {
            _reportViewerRepo = new ReportViewerRepository();
        }
        

        #endregion

        #region IGroupService Implementation

        public GetAllDataReportViewerResponse GetAllDataGroup()
        {
            GetAllDataReportViewerResponse response = new GetAllDataReportViewerResponse();
            try
            {
                List<Group> _listGroup = _reportViewerRepo.GetAll();
                response.ReportViewerList.AddRange(_listGroup);
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.ToString());
            }

            return response;
        }

        public GetAllDataReportViewerResponse GetAllDataReportViewer()
        {
            throw new NotImplementedException();
        }

        public GetDataReportViewerByIdResponse GetDataGroupById(GetDataReportViewerByIdRequest request)
        {
            GetDataReportViewerByIdResponse response = new GetDataReportViewerByIdResponse();
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                {
                    response.ReportViewer = _reportViewerRepo.GetDataById(request.ReportViewerId);
                    transScope.Complete();
                }
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.ToString());
            }

            return response;
        }

        public GetDataReportViewerByIdResponse GetDataReportViewerById(GetDataReportViewerByIdRequest request)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
