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

        public Task<BaseResponse> CreateProduct(CreateProductRequest request, int UserID)
        {
            throw new NotImplementedException();
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
        public Task<BaseResponse> CreateProduct(CreateProductRequest request, int UserID);
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
