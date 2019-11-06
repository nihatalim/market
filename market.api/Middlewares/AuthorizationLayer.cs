using market.api.Context;
using market.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace market.api.Middlewares
{
    public class AuthorizationLayer
    {
        private readonly RequestDelegate request;

        public AuthorizationLayer(RequestDelegate request)
        {
            this.request = request;
        }
        public async Task Invoke(HttpContext context, DatabaseContext database)
        {
            string token = context.Request.Headers["Token"];
            // TODO check token
            if(token != null)
            {
                // Step 1: Get user information from redis using token.
                // Step 2: If user information found, set UserID and Privileges.
                // Step 3: If user information not found, get user information from database using token.
                // Step 4: If user information found, set UserID and Privileges.
                // Step 5: If user information not found, return baseresponse with authorization error message.

                // TODO Step 1
                // TODO Step 2

                // Step 3
                User user = await database.Users.Where(a => a.Token.Equals(token)).FirstOrDefaultAsync();

                if(user != null)
                {
                    // This process is working with lazy loading.
                    List<Privilege> privileges = user.Roles.SelectMany(a => a.Role.Privileges.Select(b => b.Privilege)).ToList();

                    // Step 4
                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                    };
                    
                    if (privileges != null && privileges.Count > 0)
                    {
                        privileges.ForEach(privilege => claims.Append(new Claim(ClaimTypes.UserData, privilege.Key)));
                    }

                    context.User.AddIdentity(new ClaimsIdentity(claims));
                }
                
                /* // Step 5
                else {
                    market.dto.BaseResponse bResponse = new dto.BaseResponse();
                    bResponse.Result.Message = "Authorization failed.";

                    await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(bResponse));
                    return;
                }*/
            }

            await this.request.Invoke(context);
        }
    }
}
