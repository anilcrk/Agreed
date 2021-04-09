using Agreed.WebUI.DTOs;
using AutoMapper;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Agreed.WebUI.Helpers.ExcelModelHelper
{
    public class OrderModelHelper
    {
        public static Task<List<OrderDto>> ReadOrder(IFormFile file, string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                fileName += Guid.NewGuid().ToString() + ".xlsx";
            }

            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }

            var orders = new List<OrderDto>();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        if (reader.Depth == 0) continue;

                        orders.Add(new OrderDto()
                        {
                            Barcode = reader.GetValue(0) != null ? reader.GetValue(0).ToString() : "",
                            PackageNumber = reader.GetValue(1) != null ? reader.GetValue(1).ToString() : "",
                            CargoCompany = reader.GetValue(2) != null ? reader.GetValue(2).ToString() : "",
                            OrderDate = Convert.ToDateTime(reader.GetValue(3).ToString()),
                            CargoDeliveryDate = DateTime.Now,
                            CargoCode = reader.GetValue(5) != null ? reader.GetValue(5).ToString() : "",
                            OrderNumber = reader.GetValue(6) != null ? reader.GetValue(6).ToString() : "",
                            Receiver = reader.GetValue(7) != null ? reader.GetValue(7).ToString() : "",
                            DeliveryAddress = reader.GetValue(8) != null ? reader.GetValue(8).ToString() : "",
                            ProductName = reader.GetValue(9) != null ? reader.GetValue(9).ToString() : "",
                            BillingAddress = reader.GetValue(10) != null ? reader.GetValue(10).ToString() : "",
                            OrderStatus = reader.GetValue(11) != null ? reader.GetValue(11).ToString() : string.Empty,
                            Email = reader.GetValue(12) != null ? reader.GetValue(12).ToString() : string.Empty,
                            CommissionRate = Convert.ToDouble(reader.GetValue(13)),
                            Brand = reader.GetValue(14) != null ? reader.GetValue(14).ToString() : string.Empty,
                            StockCode = reader.GetValue(15) != null ? reader.GetValue(15).ToString() : string.Empty,
                            Piece = Convert.ToInt32(reader.GetValue(16)),
                            UnitPrice = Convert.ToDecimal(reader.GetValue(17)),
                            SalesAmount = Convert.ToDecimal(reader.GetValue(18)),
                            DiscountAmount = Convert.ToDecimal(reader.GetValue(19)),
                            AmountTobeBilled = Convert.ToDecimal(reader.GetValue(20)),
                            BoutiqueNumber = reader.GetValue(21) != null ? reader.GetValue(21).ToString() : string.Empty,
                        });
                    }
                }
            }

            // model doldurulduktan sonra file delete
            System.IO.File.Delete(fileName);

            return Task.FromResult(orders);
        }
    }
}
