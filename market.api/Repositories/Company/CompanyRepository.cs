using market.api.Context;
using market.dto;
using market.dto.Requests.Company;
using market.dto.Requests.Company.Category;
using market.dto.Requests.Company.Order;
using market.dto.Requests.Company.Product;
using market.dto.Requests.Company.Property;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Repositories.Company
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DatabaseContext context;
        public CompanyRepository(DatabaseContext context)
        {
            this.context = context;
        }

        // GetProducts(pagination + search)
        // GetProduct(id)

        // GetOrders(pagination + search)
        // GetOrder(id)

        public async Task<BaseResponse> AddProductToOrder(AddProductToOrderRequest request, int UserID)
        {
            BaseResponse response = new BaseResponse();
            Models.Company company = null;
            Models.Order order = null;
            Models.Product product = null;
            Models.OrderProduct orderProduct = null;

            company = await this.context.Companies.Where(a => a.UserID.Equals(UserID)).FirstOrDefaultAsync();
            order = await this.context.Orders.Where(a => a.ID.Equals(request.OrderID)).FirstOrDefaultAsync();
            product = await this.context.Products.Where(a => a.ID.Equals(request.ProductID)).FirstOrDefaultAsync();

            // Product and Order is property of current Company
            if (company != null && order != null && product != null &&
                company.ID.Equals(product.CompanyID) && company.ID.Equals(order.CompanyID))
            {
                try
                {
                    await this.context.Database.BeginTransactionAsync();

                    orderProduct = new Models.OrderProduct();
                    orderProduct.OrderID = order.ID;
                    orderProduct.ProductID = product.ID;
                    
                    Common.SharedRepository.PriceCalc calculated = Common.SharedRepository.PriceCalculator(request.Price, request.TaxRate, request.DiscountRate, request.Count);
                    orderProduct.Count = calculated.Count;
                    orderProduct.Price = calculated.Price;
                    orderProduct.TaxRate = calculated.TaxRate;
                    orderProduct.TaxPrice = calculated.TaxPrice;
                    orderProduct.DiscountRate = calculated.DiscountRate;
                    orderProduct.DiscountPrice = calculated.DiscountPrice;
                    orderProduct.TotalPrice = calculated.TotalPrice;

                    await this.context.OrderProducts.AddAsync(orderProduct);
                    await this.context.SaveChangesAsync();

                    this.context.Database.CommitTransaction();

                    response.Result.Status = true;
                    response.Result.Message = "Başarılı.";
                }
                catch (Exception)
                {
                    this.context.Database.RollbackTransaction();
                }
            }

            return response;
        }

        public async Task<BaseResponse> AddPropertyToProduct(AddPropertyToProductRequest request, int UserID)
        {
            BaseResponse response = new BaseResponse();
            Models.Company company = null;
            Models.Product product = null;
            Models.Property property = null;

            company = await this.context.Companies.Where(a => a.UserID.Equals(UserID)).FirstOrDefaultAsync();
            product = await this.context.Products.Where(a => a.ID.Equals(request.ProductID)).FirstOrDefaultAsync();

            if (company != null && product != null && company.ID.Equals(product.CompanyID))
            {
                property = new Models.Property();
                property.ProductID = product.ID;
                property.Name = request.Name;
                property.Value = request.Value;
                property.PropertyType = Common.SharedRepository.PropertyTypeConverter(request.PropertyType);

                await this.context.Properties.AddAsync(property);
                await this.context.SaveChangesAsync();

                response.Result.Status = true;
                response.Result.Message = "Başarılı.";
            }

            return response;
        }

        public async Task<BaseResponse> CreateCategory(CreateCategoryRequest request, int UserID)
        {
            BaseResponse response = new BaseResponse();
            Models.Company company = null;
            Models.Category category = null;

            company = await this.context.Companies.Where(a => a.UserID.Equals(UserID)).FirstOrDefaultAsync();
            
            if(company != null)
            {
                category = new Models.Category();
                category.CompanyID = company.ID;
                category.Name = request.Name;

                await this.context.Categories.AddAsync(category);
                await this.context.SaveChangesAsync();

                response.Result.Status = true;
                response.Result.Message = "Başarılı.";
            }

            return response;
        }

        public async Task<BaseResponse> CreateOrder(CreateOrderRequest request, int UserID)
        {
            BaseResponse response = new BaseResponse();

            return response;
        }

        public async Task<BaseResponse> CreateProduct(CreateProductRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> DeleteCategory(DeleteCategoryRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> DeleteCompany(DeleteCompanyRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> DeleteOrder(DeleteOrderRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> DeleteProduct(DeleteProductRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> DeleteProductFromOrder(DeleteProductFromOrderRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> DeletePropertyFromProduct(DeletePropertyFromProductRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> RegisterCompany(RegisterCompanyRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> UpdateCategory(UpdateCategoryRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> UpdateCompany(UpdateCompanyRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> UpdateOrder(UpdateOrderRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> UpdateProduct(UpdateProductRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> UpdateProductFromOrder(UpdateProductFromOrderRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> UpdateProperty(UpdatePropertyRequest request, int UserID)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICompanyRepository
    {
        public Task<BaseResponse> RegisterCompany(RegisterCompanyRequest request);
        public Task<BaseResponse> UpdateCompany(UpdateCompanyRequest request, int UserID);
        public Task<BaseResponse> DeleteCompany(DeleteCompanyRequest request, int UserID);

        #region Category
        public Task<BaseResponse> CreateCategory(CreateCategoryRequest request, int UserID);
        public Task<BaseResponse> DeleteCategory(DeleteCategoryRequest request, int UserID);
        public Task<BaseResponse> UpdateCategory(UpdateCategoryRequest request, int UserID);
        #endregion

        #region Order
        public Task<BaseResponse> CreateOrder(CreateOrderRequest request, int UserID);
        public Task<BaseResponse> DeleteOrder(DeleteOrderRequest request, int UserID);
        public Task<BaseResponse> UpdateOrder(UpdateOrderRequest request, int UserID);
        public Task<BaseResponse> AddProductToOrder(AddProductToOrderRequest request, int UserID);
        public Task<BaseResponse> DeleteProductFromOrder(DeleteProductFromOrderRequest request, int UserID);
        public Task<BaseResponse> UpdateProductFromOrder(UpdateProductFromOrderRequest request, int UserID);
        #endregion

        #region Product
        public Task<BaseResponse> CreateProduct(CreateProductRequest request, int UserID);
        public Task<BaseResponse> DeleteProduct(DeleteProductRequest request, int UserID);
        public Task<BaseResponse> UpdateProduct(UpdateProductRequest request, int UserID);
        #endregion

        #region Property
        public Task<BaseResponse> AddPropertyToProduct(AddPropertyToProductRequest request, int UserID);
        public Task<BaseResponse> DeletePropertyFromProduct(DeletePropertyFromProductRequest request, int UserID);
        public Task<BaseResponse> UpdateProperty(UpdatePropertyRequest request, int UserID);

        #endregion

    }
}
