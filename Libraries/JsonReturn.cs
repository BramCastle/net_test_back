using net_test.Libraries;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace net_test.Libraries
{
    public class JsonReturn
    {
        public bool Session         = true;
        public bool Action          = false;
        public dynamic Result       = null;
        public string Title         = "";
        public string Message       = "";
        public string Code          = "";

        public void Success(SuccessMessage success) {
            Action = true;
            Title = success.Title;
            Message = success.Message;
            Code = success.Code;
        }

        public void Exception(ExceptionMessage exception) {
            Action = false;
            Title = exception.Title;
            Message = exception.Message;
            Code = exception.Code;
        }

        public void Exception(AppException exception) {
            Action = false;
            Title = exception.Title;
            Message = exception.Message;
            Code = exception.Code;
        }

        public OkObjectResult build() {
            return new OkObjectResult(this);
        }
    }
}