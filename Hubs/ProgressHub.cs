using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ProCoding.Demos.ASPNetCore.SignalR.Hubs
{
    public class ProgressHub : Hub<IProgressHubClientFunctions>
    {
        public async Task<int> SubscribeForNotifications(string operationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, operationId);
            return LongRunningOperation.GetCurrentProgress(operationId);
        }

        public Task CancelProcessing(string operationId)
        {
            Clients.Group(operationId).SetMessage("Cancellation Requested...");
            LongRunningOperation.CancelProcessing(operationId);
            return Task.CompletedTask;
        }
    }

    public interface IProgressHubClientFunctions
    {
         Task SetProgress(int progress);
         Task SetMessage(string message);        
    }
}