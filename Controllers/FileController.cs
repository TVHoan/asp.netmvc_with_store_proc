using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace netmvc.Controllers
{

    public class FileController: ApiController {
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("api/uploadfile")]
        public async Task<string> UploadFile(HttpPostedFileBase  file)
        {
            if (file != null && file.ContentLength > 0)  
            try 
            {  
                string path = Path.Combine( System.Web.HttpContext.Current.Server.MapPath("~/Images"),  
                    Path.GetFileName(file.FileName));  
                file.SaveAs(path);
                return "~/Images/" + file.FileName;
            }  
            catch (Exception ex)
            {
                return string.Empty;
            }
            return string.Empty;
        }
    }
}