using market.api.Context;
using market.api.Models;
using market.dto.Requests.Common;
using market.dto.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Repositories.Common
{
    public class CommonRepository : ICommonRepository
    {
        private readonly DatabaseContext context;

        public CommonRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();

            User user = await this.context.Users
                                    .Where(a => a.Mail.Equals(request.Mail))
                                    .Where(a => a.Password.Equals(request.Password))
                                    .FirstOrDefaultAsync();

            if (user == null)
            {
                response.Result.Message = "Bu mail ve şifre kombinasyonuna sahip bir kullanıcı bulunamadı.";
            }
            else
            {
                if (user.ExpirationDate.CompareTo(DateTime.UtcNow) < 0)
                {
                    user.ExpirationDate = DateTime.UtcNow.AddDays(1);
                    user.Token = this.GenerateToken();
                    await this.context.SaveChangesAsync();
                }

                response.Token = user.Token;
                response.Result.Status = true;
                response.Result.Message = "Başarılı.";
            }

            return response;
        }

        public string GenerateToken() => Convert.ToBase64String(Guid.NewGuid().ToByteArray());

    }

    public interface ICommonRepository
    {
        public Task<LoginResponse> LoginAsync(LoginRequest request);
        public string GenerateToken();
    }
}
