using System.Net.Http;
using System.Web;

public class Conf
{
    public static string TitlePage
    {
        get
        {
            return ":: KNSS - WEB :: ";
        }
    }

    public static string TempFolder
    {
        get
        {
            return HttpContext.Current.Server.MapPath("~/Assets/img/temp/");
        }
    }

    public static string Folder
    {
        get
        {
            return HttpContext.Current.Server.MapPath("~/Assets/img/");
        }
    }

    public static string EmployeeFolder
    {
        get
        {
            return HttpContext.Current.Server.MapPath("~/assets/img/employee/");
        }
    }

    public static string DocumentFolder
    {
        get
        {
            return HttpContext.Current.Server.MapPath("~/assets/img/document/");
        }
    }


    public static string ReportFolder
    {
        get
        {
            return HttpContext.Current.Server.MapPath("~/Reports/Rpt/");
        }
    }

    public static string ImportFolder
    {
        get
        {
            return HttpContext.Current.Server.MapPath("~/assets/img/import/");
        }
    }

    public static string ImportTempleteFolder
    {
        get
        {
            return HttpContext.Current.Server.MapPath("~/assets/img/import_templete/");
        }
    }
    public static string CutOffTemplateFolder
    {
        get
        {
            return HttpContext.Current.Server.MapPath("~/assets/CutOffTemplate/");
        }
    }
    public static double MaxUpload()
    {
        return 10000000;
    }
}