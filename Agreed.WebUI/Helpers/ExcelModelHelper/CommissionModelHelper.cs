using Agreed.Core.Entities;
using Agreed.WebUI.DTOs;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Agreed.WebUI.Helpers.ExcelModelHelper
{
    public class CommissionModelHelper
    {
        public static Task<List<CommissionDto>> ReadCommision(IFormFile file, string fileName)
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

            var commmisions = new List<CommissionDto>();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        if (reader.Depth == 0) continue;

                        //commmisions.Add(new CommissionDto()
                        //{
                        //    TransactionId = reader.GetValue(0) != null ? reader.GetValue(0).ToString() : "",
                        //    ProcessType = reader.GetValue(1) != null ? reader.GetValue(1).ToString() : "",
                        //    OrderNumber = reader.GetValue(2) != null ? reader.GetValue(2).ToString() : "",
                        //    OdemeStatus = reader.GetValue(5) != null ? reader.GetValue(5).ToString() : "",
                        //    ProcessDate = reader.GetValue(6) != null ? Convert.ToDateTime(reader.GetValue(6)) : new DateTime(),
                        //    Seller = reader.GetValue(7) != null ? reader.GetValue(7).ToString() : "",
                        //    VendorCurrentName = reader.GetValue(8) != null ? reader.GetValue(8).ToString() : "",
                        //    ProductName = reader.GetValue(9) != null ? reader.GetValue(9).ToString() : "",
                        //    Barcode = reader.GetValue(10) != null ? reader.GetValue(10).ToString() : "",
                        //    CommissionRate = Convert.ToDouble(reader.GetValue(17)),
                        //    TYProgressPayment = Convert.ToDouble(reader.GetValue(17)),
                        //    SellerProgressPayment = Convert.ToDouble(reader.GetValue(17)),
                        //    TermTime = Convert.ToInt32(reader.GetValue(18)),
                        //    AgreeDate = reader.GetValue(6) != null ? Convert.ToDateTime(reader.GetValue(6)) : new DateTime(),
                        //    ShippingDate = reader.GetValue(6) != null ? Convert.ToDateTime(reader.GetValue(6)) : new DateTime(),
                        //    TermDate = reader.GetValue(6) != null ? Convert.ToDateTime(reader.GetValue(6)) : new DateTime(),
                        //    CommissionInvoiceNumber = reader.GetValue(10) != null ? reader.GetValue(10).ToString() : "",
                        //    TotalAmount = Convert.ToDouble(reader.GetValue(17))

                        //});

                        var commission = new CommissionDto();
                        commission.TransactionId = reader.GetValue(0) != null ? reader.GetValue(0).ToString() : "";
                        commission.ProcessType = reader.GetValue(1) != null ? reader.GetValue(1).ToString() : "";
                        commission.OrderNumber = reader.GetValue(2) != null ? reader.GetValue(2).ToString() : "";
                        commission.OrderDate = reader.GetValue(3) != null ? Convert.ToDateTime(reader.GetValue(3)) : new DateTime();
                        commission.OdemeStatus = reader.GetValue(4) != null ? reader.GetValue(4).ToString() : "";
                        commission.ProcessDate = reader.GetValue(5) != null ? Convert.ToDateTime(reader.GetValue(5)) : new DateTime();
                        commission.Seller = reader.GetValue(6) != null ? reader.GetValue(6).ToString() : "";
                        commission.VendorCurrentName = reader.GetValue(7) != null ? reader.GetValue(7).ToString() : "";
                        commission.ProductName = reader.GetValue(8) != null ? reader.GetValue(8).ToString() : "";
                        commission.Barcode = reader.GetValue(9) != null ? reader.GetValue(9).ToString() : "";
                        commission.CommissionRate = Convert.ToDouble(reader.GetValue(10));
                        commission.TYProgressPayment = Convert.ToDouble(reader.GetValue(11));
                        commission.SellerProgressPayment = Convert.ToDouble(reader.GetValue(12));
                        commission.TermTime = Convert.ToInt32(reader.GetValue(13));
                        commission.AgreeDate = reader.GetValue(14) != null ? Convert.ToDateTime(reader.GetValue(14)) : new DateTime();
                        commission.Deliverydate = reader.GetValue(15) != null ? Convert.ToDateTime(reader.GetValue(15)) : new DateTime();
                        commission.TermDate = reader.GetValue(16) != null ? Convert.ToDateTime(reader.GetValue(16)) : new DateTime();
                        commission.CommissionInvoiceNumber = reader.GetValue(17) != null ? reader.GetValue(17).ToString() : "";
                        commission.TotalAmount = Convert.ToDouble(reader.GetValue(18));
                        commission.Name = reader.GetValue(19) != null ? reader.GetValue(19).ToString() : "";
                        commission.Surname = reader.GetValue(20) != null ? reader.GetValue(20).ToString() : "";
                        commission.ShippingDate = reader.GetValue(21) != null ? Convert.ToDateTime(reader.GetValue(21)) : new DateTime();

                        commmisions.Add(commission);
                    }
                }
            }
        

        // model doldurulduktan sonra file delete
        System.IO.File.Delete(fileName);

            return Task.FromResult(commmisions);
        }
}
}
