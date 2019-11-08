using market.api.Context;
using market.api.Repositories.Common;
using market.dto;
using market.dto.Requests.Company;
using market.dto.Requests.Company.Category;
using market.dto.Requests.Company.Client;
using market.dto.Requests.Company.Order;
using market.dto.Requests.Company.Product;
using market.dto.Requests.Company.Property;
using market.dto.Requests.Company.Role;
using market.dto.Requests.Company.User;
using market.dto.Responses.Company.Category;
using market.dto.Responses.Company.Client;
using market.dto.Responses.Company.Order;
using market.dto.Responses.Company.Product;
using market.dto.Responses.Company.Role;
using market.dto.Responses.Company.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Repositories.Company
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DatabaseContext context;
        private readonly SharedRepository sharedRepository;
        public CompanyRepository(DatabaseContext context, SharedRepository sharedRepository)
        {
            this.context = context;
            this.sharedRepository = sharedRepository;
        }

        public Task<BaseResponse> AddProductToOrder(AddProductToOrderRequest request, int UserID)
        {
            Models.Order order = null;
            Models.Product product = null;
            Models.OrderProduct orderProduct = null;



            
            throw new NotImplementedException();
        }

        public Task<BaseResponse> AddPropertyToProduct(AddPropertyToProductRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> AddUserToRole(AddUserToRoleRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> ChangeCompanyStatus(ChangeCompanyStatusRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> ChangeOrderStatus(ChangeOrderStatusRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> ConfirmOrder(ConfirmOrderRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> CreateCategory(CreateCategoryRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> CreateClient(CreateClientRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> CreateOrder(CreateOrderRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> CreateProduct(CreateProductRequest request, int UserID, int CompanyID)
        {
            BaseResponse response = new BaseResponse();
            Models.Product product = null;
            Models.Company company = null;
            Models.Category category = null;
            Models.Property property = null;

            category = request.CategoryID.HasValue ? 
                        await this.context.Categories.Where(a => a.ID.Equals(request.CategoryID)).FirstOrDefaultAsync() : 
                        null;

            try
            {
                await context.Database.BeginTransactionAsync();

                product = new Models.Product();
                product.Name = request.Name;
                product.Barcode = request.Barcode;
                product.Price = request.Price;
                product.TaxRate = request.TaxRate;
                product.TotalPrice = Decimal.Add(product.Price, Decimal.Multiply(product.Price, Decimal.Divide(product.TaxRate, 100)));
                product.CategoryID = category != null ? (int?)category.ID : null;
                product.CompanyID = CompanyID;

                context.Products.Add(product);
                await context.SaveChangesAsync();

                if(request.Properties != null && request.Properties.Count > 0)
                {
                    foreach(dto.Models.Property dtoProp in request.Properties)
                    {
                        property = new Models.Property();
                        property.Name = dtoProp.Name;
                        property.ProductID = product.ID;
                        property.Value = dtoProp.Value;
                        property.Type = dtoProp.Type != null ? sharedRepository.PropertyTypeConverter(dtoProp.Type) : Models.PropertyType.STRING;
                        context.Properties.Add(property);
                        await context.SaveChangesAsync();
                    }
                }

                context.Database.CommitTransaction();

                response.Result.Status = true;
                response.Result.Message = "Operation successful";
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
            }

            return response;
        }

        public Task<BaseResponse> CreateRole(CreateRoleRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> DeleteCategory(DeleteCategoryRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> DeleteClient(DeleteClientRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> DeleteOrder(DeleteOrderRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> DeleteProduct(DeleteProductRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> DeleteProductFromOrder(DeleteProductFromOrderRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> DeletePropertyFromProduct(DeletePropertyFromProductRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> DeleteRole(DeleteRoleRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> DeleteUserFromRole(DeleteUserFromRoleRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllCategoriesResponse> GetAllCategories(GetAllCategoriesRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllClientsResponse> GetAllClients(GetAllClientsRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllOrdersResponse> GetAllOrders(GetAllOrdersRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllProductsResponse> GetAllProducts(GetAllProductsRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllRolesResponse> GetAllRoles(GetAllRolesRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllUsersResponse> GetAllUsers(GetAllUsersRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<GetClientOrdersResponse> GetClientOrders(GetClientOrdersRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> UpdateCategory(UpdateCategoryRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> UpdateClient(UpdateClientRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> UpdateOrder(UpdateOrderRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> UpdateProduct(UpdateProductRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> UpdateProductFromOrder(UpdateProductFromOrderRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> UpdateProperty(UpdatePropertyRequest request, int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> UpdateRole(UpdateRoleRequest request, int UserID)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICompanyRepository
    {
        public Task<BaseResponse> ChangeCompanyStatus(ChangeCompanyStatusRequest request);

        #region Category
        public Task<BaseResponse> CreateCategory(CreateCategoryRequest request, int UserID);
        public Task<BaseResponse> DeleteCategory(DeleteCategoryRequest request, int UserID);
        public Task<BaseResponse> UpdateCategory(UpdateCategoryRequest request, int UserID);
        public Task<GetAllCategoriesResponse> GetAllCategories(GetAllCategoriesRequest request, int UserID);
        #endregion

        #region Client
        public Task<BaseResponse> CreateClient(CreateClientRequest request, int UserID);
        public Task<BaseResponse> DeleteClient(DeleteClientRequest request, int UserID);
        public Task<BaseResponse> UpdateClient(UpdateClientRequest request, int UserID);
        public Task<GetAllClientsResponse> GetAllClients(GetAllClientsRequest request, int UserID);
        public Task<GetClientOrdersResponse> GetClientOrders(GetClientOrdersRequest request, int UserID);
        #endregion

        #region Order
        public Task<BaseResponse> AddProductToOrder(AddProductToOrderRequest request, int UserID);
        public Task<BaseResponse> ChangeOrderStatus(ChangeOrderStatusRequest request, int UserID);
        public Task<BaseResponse> ConfirmOrder(ConfirmOrderRequest request, int UserID);
        public Task<BaseResponse> CreateOrder(CreateOrderRequest request, int UserID);
        public Task<BaseResponse> DeleteOrder(DeleteOrderRequest request, int UserID);
        public Task<BaseResponse> DeleteProductFromOrder(DeleteProductFromOrderRequest request, int UserID);
        public Task<GetAllOrdersResponse> GetAllOrders(GetAllOrdersRequest request, int UserID);
        public Task<BaseResponse> UpdateOrder(UpdateOrderRequest request, int UserID);
        public Task<BaseResponse> UpdateProductFromOrder(UpdateProductFromOrderRequest request, int UserID);
        #endregion

        #region Product
        public Task<BaseResponse> CreateProduct(CreateProductRequest request, int UserID, int CompanyID);
        public Task<BaseResponse> DeleteProduct(DeleteProductRequest request, int UserID);
        public Task<BaseResponse> UpdateProduct(UpdateProductRequest request, int UserID);
        public Task<GetAllProductsResponse> GetAllProducts(GetAllProductsRequest request, int UserID);

        #region Property
        public Task<BaseResponse> AddPropertyToProduct(AddPropertyToProductRequest request, int UserID);
        public Task<BaseResponse> DeletePropertyFromProduct(DeletePropertyFromProductRequest request, int UserID);
        public Task<BaseResponse> UpdateProperty(UpdatePropertyRequest request, int UserID);
        #endregion

        #endregion

        #region Role
        public Task<BaseResponse> AddUserToRole(AddUserToRoleRequest request, int UserID);
        public Task<BaseResponse> CreateRole(CreateRoleRequest request, int UserID);
        public Task<BaseResponse> DeleteRole(DeleteRoleRequest request, int UserID);
        public Task<BaseResponse> DeleteUserFromRole(DeleteUserFromRoleRequest request, int UserID);
        public Task<GetAllRolesResponse> GetAllRoles(GetAllRolesRequest request, int UserID);
        public Task<BaseResponse> UpdateRole(UpdateRoleRequest request, int UserID);
        #endregion

        #region User
        public Task<GetAllUsersResponse> GetAllUsers(GetAllUsersRequest request, int UserID);
        #endregion
    }
}
