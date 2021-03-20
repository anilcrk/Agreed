using Agreed.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agreed.DataAccess.Seed
{
    public class OrderSeed : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order
                {
                    AmountTobeBilled = 150,
                    BillingAddress = "İstanbul",
                    DeliveryAddress = "Denizli",
                    DiscountAmount = 10,
                    SalesAmount = 150,
                    Barcode = "0000000000001998",
                    BoutiqueNumber = "123456",
                    Brand = "HAC",
                    CargoCode = "123456",
                    CargoCompany = "HAC CARGO",
                    CargoDeliveryDate = DateTime.Now,
                    CommissionRate = 10.5,
                    Email = "anil@hacyazilim.com.tr",
                    OrderDate = DateTime.Now.AddDays(-7),
                    OrderNumber = "123",
                    OrderStatus = Core.Enums.OrderStatus.Created,
                    StockCode = "aaaa",
                    PackageNumber = "123",
                    Piece = 1,
                    ProductName = "HAC",
                    Receiver = string.Empty,
                    UnitPrice = 150


                });
        }
    }
}
