using market.api.Context;
using market.dto;
using market.dto.Requests.Common;
using market.dto.Responses.Common;
using System;
using System.Threading.Tasks;

namespace market.api.Repositories.Common
{
    public class CommonRepository : ICommonRepository
    {
        private readonly DatabaseContext context;
        private readonly SharedRepository sharedRepository;

        public CommonRepository(DatabaseContext context, SharedRepository sharedRepository)
        {
            this.context = context;
            this.sharedRepository = sharedRepository;
        }

        public Task<LoginResponse> Login(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> UpdateUser(UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICommonRepository
    {
        public Task<LoginResponse> Login(LoginRequest request);
        public Task<BaseResponse> UpdateUser(UpdateUserRequest request);
    }
}
