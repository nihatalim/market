using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Repositories.Common
{
    public class SharedRepository
    {
        public static api.Models.PropertyType PropertyTypeConverter(dto.Models.PropertyType propertyType)
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
        public static dto.Models.PropertyType PropertyTypeConverter(api.Models.PropertyType propertyType)
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
        public static PriceCalc PriceCalculator(decimal Price, decimal TaxRate = 18, decimal DiscountRate = 0, int Count = 1) => new PriceCalc(Price, TaxRate, DiscountRate, Count);

        public class PriceCalc
        {
            public int Count { get; set; }
            public decimal Price { get; set; }
            public decimal TaxRate { get; set; }
            public decimal DiscountRate { get; set; }
            public decimal TaxPrice => Decimal.Multiply(
                                        Decimal.Multiply(
                                            Decimal.Divide(this.TaxRate, 100), this.Price), this.Count);
            public decimal DiscountPrice => Decimal.Multiply(
                                            Decimal.Multiply(
                                                Decimal.Divide(this.DiscountRate, 100), this.Price), this.Count);
            public decimal TotalPrice => Decimal.Subtract(Decimal.Add(this.Price, this.TaxPrice), this.DiscountPrice);
            public PriceCalc(decimal Price, decimal TaxRate = 18, decimal DiscountRate = 0, int Count = 1)
            {
                this.Count = Count;
                this.Price = Price;
                this.TaxRate = TaxRate;
                this.DiscountRate = DiscountRate;
            }
        }

    }


}
