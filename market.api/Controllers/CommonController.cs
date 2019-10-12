using market.api.Repositories.Common;
using market.dto.Requests.Common;
using market.dto.Responses;
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
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            // Get UserID which assigned to claims by middleware
            //int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.commonRepository.LoginAsync(request);
        }
    }
}
