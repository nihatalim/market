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
                User user = await database.Users.Where(a => a.Token.Equals(token))
                .FirstOrDefaultAsync();

                if(user != null)
                {
                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                        new Claim(ClaimTypes.Role, user.Role.ToString())
                    };

                    context.User.AddIdentity(new ClaimsIdentity(claims));
                }
            }

            await this.request.Invoke(context);
        }
    }
}
