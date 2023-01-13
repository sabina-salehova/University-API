using Univeristy.AuthenticationService.Models;

namespace Univeristy.AuthenticationService.Contracts
{
    public interface IAuthService
    {
        string GetToken(TokenRequestModel model);
    }
}
