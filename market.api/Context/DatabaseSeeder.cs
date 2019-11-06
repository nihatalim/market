using market.api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Context
{
    public static class DatabaseSeeder
    {
        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            DatabaseContext context = applicationBuilder.ApplicationServices.GetRequiredService<DatabaseContext>();
            context.Privileges.AddRange(Models.Privilege.GetInitialPrivileges());
            context.SaveChanges();
        }
    }
}
