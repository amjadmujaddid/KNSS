using KNSSEF.DAL;
using KNSSEF.DAL.Interface;
using KNSSService.Contract;
using System;
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

        #region IReportService Implementation

        public GetAllDataReportViewerResponse GetAllDataReport()
        {
            var response = new GetAllDataReportViewerResponse();
            try
            {
                var _listReport = _reportViewerRepo.GetAll();
                response.ReportViewerList.AddRange(_listReport);
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

        public GetDataReportViewerByIdResponse GetDataReportViewerById(GetDataReportViewerByIdRequest request)
        {
            var response = new GetDataReportViewerByIdResponse();
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

        #endregion
    }
}
