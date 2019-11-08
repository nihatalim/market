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
            Company company = null;
            User user = null;

            string token = context.Request.Headers["Token"];
            string companyID = context.Request.Headers["CompanyID"];

            if(token != null)
            {
                user = await database.Users.Where(a => a.Token.Equals(token)).FirstOrDefaultAsync();

                if(user != null)
                {
                    company = await database.Companies.Where(a => a.ID.Equals(companyID)).FirstOrDefaultAsync();

                    if(company != null)
                    {
                        // This process is working with lazy loading.
                        List<Privilege> privileges = user.Roles.Where(a => a.CompanyID.Equals(company.ID)).SelectMany(a => a.Role.Privileges.Select(b => b.Privilege)).Distinct().ToList();

                        // Step 4
                        Claim[] claims = new Claim[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                            new Claim("CompanyID", company.ID.ToString()),
                        };

                        if (privileges != null && privileges.Count > 0)
                        {
                            privileges.ForEach(privilege => claims.Append(new Claim(ClaimTypes.UserData, privilege.Key)));
                        }

                        context.User.AddIdentity(new ClaimsIdentity(claims));
                        await this.request.Invoke(context);
                    }
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
