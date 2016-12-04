using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

namespace TicTacToe.ServiceLayer.IdentityConfiguration
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return Task.FromResult(0);
        }
    }
}