using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Helper
{
    //public class ResultHelper
    //{
    //}

    public static class ResultHelper
    {
        /// <summary>
        /// Returns a status 404 to the client and the error 404 view.
        /// </summary>
        /// <param name="emptyBody">true: the response ends</param>
        public static ActionResult NotFoundResult(AnPhu.Website.Controllers.BaseController controller, bool emptyBody)
        {
            controller.ControllerContext.HttpContext.Response.StatusCode = 404;
            if (emptyBody)
            {
                controller.ControllerContext.HttpContext.Response.End();
            }

            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "Errors/404";
            viewResult.MasterName = controller.GetDefaultMasterName();
            return viewResult;

        }
        public static ActionResult NotFoundResult(AnPhu.Website.Controllers.BaseController controller)
        {
            return NotFoundResult(controller, false);
        }

    }
}