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
    public class CargoModelHelper
    {
        public static Task<List<CargoDto>> ReadCargo(IFormFile file, string fileName)
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

            var cargoes = new List<CargoDto>();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        if (reader.Depth == 0) continue;

                        var cargo = new CargoDto();

                        cargo.SellerID = reader.GetValue(0) != null ? reader.GetValue(0).ToString() : "";
                        cargo.ShipmentFee = Convert.ToDouble(reader.GetValue(1));
                        cargo.Desi = reader.GetValue(2) != null ? reader.GetValue(2).ToString() : "";
                        cargo.SellerName = reader.GetValue(3) != null ? reader.GetValue(3).ToString() : "";
                        cargo.OrderNo = reader.GetValue(4) != null ? reader.GetValue(4).ToString() : "";
                        cargo.ShipmentIsReturns = reader.GetValue(5) != null ? reader.GetValue(5).ToString() : "";
                        cargo.ShipmentIsReturnCode = reader.GetValue(6) != null ? reader.GetValue(6).ToString() : "";
                        cargo.CargoCompany = reader.GetValue(7) != null ? reader.GetValue(7).ToString() : "";
                        cargo.OrderDate = reader.GetValue(8) != null ? Convert.ToDateTime(reader.GetValue(8)) : new DateTime();
                        cargo.ShipmentDate = reader.GetValue(9) != null ? Convert.ToDateTime(reader.GetValue(9)) : new DateTime();
                        cargo.OrderAmount = Convert.ToDouble(reader.GetValue(10));
                        cargo.MinCampaignScale = reader.GetValue(11) != null ? reader.GetValue(11).ToString() : "";
                        cargo.NumberOfProducts = reader.GetValue(12) != null ? reader.GetValue(12).ToString() : "";
                        cargo.BoutiqueId = reader.GetValue(13) != null ? reader.GetValue(13).ToString() : "";

                        cargoes.Add(cargo);
                    }
                }
            }


            // model doldurulduktan sonra file delete
            System.IO.File.Delete(fileName);

            return Task.FromResult(cargoes);
        }
    }
}
