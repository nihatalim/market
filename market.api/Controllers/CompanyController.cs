using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using market.api.Repositories.Company;
using market.dto;
using market.dto.Requests.Common;
using market.dto.Requests.Company;
using market.dto.Requests.Company.Category;
using market.dto.Requests.Company.Order;
using market.dto.Requests.Company.Product;
using market.dto.Requests.Company.Property;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace market.api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/company")]
    [Authorize(Policy = "Authorized")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository repository;
        public CompanyController(ICompanyRepository repository)
        {
            this.repository = repository;
        }

        [Authorize(Policy = "AddProductToOrderPrivilege")]
        [HttpPost("AddProductToOrder")]
        public async Task<BaseResponse> AddProductToOrder(AddProductToOrderRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.AddProductToOrder(request, id);
        }
        
        [Authorize(Policy = "AddProductToOrderPrivilege")]
        [HttpPost("AddPropertyToProduct")]
        public async Task<BaseResponse> AddPropertyToProduct(AddPropertyToProductRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.AddPropertyToProduct(request, id);
        }

        [HttpPost("CreateCategory")]
        public async Task<BaseResponse> CreateCategory(CreateCategoryRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.CreateCategory(request, id);
        }

        [HttpPost("CreateOrder")]
        public async Task<BaseResponse> CreateOrder(CreateOrderRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.CreateOrder(request, id);
        }

        [HttpPost("CreateProduct")]
        public async Task<BaseResponse> CreateProduct(CreateProductRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.CreateProduct(request, id);
        }

        [HttpPost("DeleteCategory")]
        public async Task<BaseResponse> DeleteCategory(DeleteCategoryRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.DeleteCategory(request, id);
        }

        [HttpPost("DeleteCompany")]
        public async Task<BaseResponse> DeleteCompany(DeleteCompanyRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.DeleteCompany(request, id);
        }

        [HttpPost("DeleteOrder")]
        public async Task<BaseResponse> DeleteOrder(DeleteOrderRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.DeleteOrder(request, id);
        }

        [HttpPost("DeleteProduct")]
        public async Task<BaseResponse> DeleteProduct(DeleteProductRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.DeleteProduct(request, id);
        }

        [HttpPost("DeleteProductFromOrder")]
        public async Task<BaseResponse> DeleteProductFromOrder(DeleteProductFromOrderRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.DeleteProductFromOrder(request, id);
        }

        [HttpPost("DeletePropertyFromProduct")]
        public async Task<BaseResponse> DeletePropertyFromProduct(DeletePropertyFromProductRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.DeletePropertyFromProduct(request, id);
        }

        [HttpPost("RegisterCompany")]
        public async Task<BaseResponse> RegisterCompany(RegisterCompanyRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.RegisterCompany(request);
        }

        [HttpPost("UpdateCategory")]
        public async Task<BaseResponse> UpdateCategory(UpdateCategoryRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.UpdateCategory(request, id);
        }

        [HttpPost("UpdateCompany")]
        public async Task<BaseResponse> UpdateCompany(UpdateCompanyRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.UpdateCompany(request, id);
        }

        [HttpPost("UpdateOrder")]
        public async Task<BaseResponse> UpdateOrder(UpdateOrderRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.UpdateOrder(request, id);
        }

        [HttpPost("UpdateProduct")]
        public async Task<BaseResponse> UpdateProduct(UpdateProductRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.UpdateProduct(request, id);
        }

        [HttpPost("UpdateProductFromOrder")]
        public async Task<BaseResponse> UpdateProductFromOrder(UpdateProductFromOrderRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.UpdateProductFromOrder(request, id);
        }

        [HttpPost("UpdateProperty")]
        public async Task<BaseResponse> UpdateProperty(UpdatePropertyRequest request)
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.Where(a => a.Type.Equals(ClaimTypes.NameIdentifier)).FirstOrDefault().Value);
            return await this.repository.UpdateProperty(request, id);
        }
    }
}
