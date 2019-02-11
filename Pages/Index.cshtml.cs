using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using ProCoding.Demos.ASPNetCore.SignalR.Hubs;

namespace ProCoding.Demos.ASPNetCore.SignalR.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet([FromServices] IHubContext<ProgressHub, IProgressHubClientFunctions> progressHub)
        {
            string operationId = Guid.NewGuid().ToString();
            Task longRunningTask = new LongRunningOperation(progressHub).DoOperation(operationId);
            ViewData["operationId"] = operationId;
        }
    }
}
