using market.api.Repositories.Common;
using market.dto;
using market.dto.Requests.Common;
using market.dto.Responses.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace market.api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/common")]
    public class CommonController : ControllerBase
    {
        private readonly ICommonRepository commonRepository;
        public CommonController(ICommonRepository commonRepository)
        {
            this.commonRepository = commonRepository;
        }

        [HttpPost("Login")]
        public async Task<LoginResponse> Login([FromBody] LoginRequest request)
        {
            return await commonRepository.Login(request);
        }

        [HttpPost("UpdateUser")]
        public async Task<BaseResponse> UpdateUser(UpdateUserRequest request)
        {
            return await commonRepository.UpdateUser(request);
        }
    }
}
