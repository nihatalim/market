using market.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Repositories.Common
{
    public class SharedRepository
    {
        public api.Models.PropertyType PropertyTypeConverter(dto.Models.PropertyType propertyType)
        {
            switch (propertyType)
            {
                case dto.Models.PropertyType.DECIMAL:
                    return api.Models.PropertyType.DECIMAL;
                case dto.Models.PropertyType.INT:
                    return api.Models.PropertyType.INT;
                case dto.Models.PropertyType.JSON:
                    return api.Models.PropertyType.JSON;
                case dto.Models.PropertyType.STRING:
                    return api.Models.PropertyType.STRING;
                default: return api.Models.PropertyType.STRING;
            }
        }
        public dto.Models.PropertyType PropertyTypeConverter(api.Models.PropertyType propertyType)
        {
            switch (propertyType)
            {
                case api.Models.PropertyType.DECIMAL:
                    return dto.Models.PropertyType.DECIMAL;
                case api.Models.PropertyType.INT:
                    return dto.Models.PropertyType.INT;
                case api.Models.PropertyType.JSON:
                    return dto.Models.PropertyType.JSON;
                case api.Models.PropertyType.STRING:
                    return dto.Models.PropertyType.STRING;
                default: return dto.Models.PropertyType.STRING;
            }
        }
        public api.Models.OrderType OrderTypeConverter(dto.Models.OrderType orderType)
        {
            switch (orderType)
            {
                case dto.Models.OrderType.IN:
                    return api.Models.OrderType.IN;
                case dto.Models.OrderType.OUT:
                    return api.Models.OrderType.OUT;
                default: return api.Models.OrderType.IN;
            }
        }
        public dto.Models.OrderType OrderTypeConverter(api.Models.OrderType orderType)
        {
            switch (orderType)
            {
                case api.Models.OrderType.IN:
                    return dto.Models.OrderType.IN;
                case api.Models.OrderType.OUT:
                    return dto.Models.OrderType.OUT;
                default: return dto.Models.OrderType.IN;
            }
        }
        public string GenerateToken() => Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }
}
