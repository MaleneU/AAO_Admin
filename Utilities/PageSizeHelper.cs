using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAO_AdminPanel.Utilities
{
    public static class PageSizeHelper
    { 
        // Get page size from select or cookie
        public static int SetPageSize(HttpContext httpContext, int? pageSizeID)
        {
            int pageSize;
            if (pageSizeID.HasValue)
            {
                // Take value from list and save to cookie
                pageSize = pageSizeID.GetValueOrDefault();
                CookieHelper.CookieSet(httpContext, "pageSizeValue", pageSize.ToString(), 30);
            }
            else
            {
                // Value is in cookie
                pageSize = Convert.ToInt32(httpContext.Request.Cookies["pageSizeValue"]);
            }
            return (pageSize == 0) ? 10 : pageSize; // Default value
        }

        // SelectList for page size choices
        public static SelectList PageSizeList(int? pageSize)
        {
            return new SelectList(new[] { "5", "10", "25", "50" }, pageSize.ToString());
        }
    }
}
