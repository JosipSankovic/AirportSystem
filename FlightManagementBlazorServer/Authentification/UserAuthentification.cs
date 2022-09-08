using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace FlightManagementBlazorServer.Authentification
{
    public class UserAuthentication : AuthenticationStateProvider
    {

       
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
           
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }

        public void CreateUser(string Username,string Role) {

            var identity = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, Username),
            new Claim(ClaimTypes.Role,Role)
            },"Authorized");
            var user = new ClaimsPrincipal(identity);

            
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
