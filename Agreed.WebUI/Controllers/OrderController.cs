using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Agreed.Core.Entities;
using Agreed.Core.Enums;
using Agreed.Core.Services;
using Agreed.WebUI.DTOs;
using AutoMapper;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agreed.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;

        public OrderController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Index(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            var orders = this.ReadAndAddRangeOrder(file.FileName);

            //return Index(orders);

            return View();
        }

        private List<OrderDto> ReadAndAddRangeOrder(string fName)
        {
            List<OrderDto> orders = new List<OrderDto>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            ViewBag.fName = $"{@"wwwroot\files"}" + "\\" + fName;
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
                            CargoDeliveryDate = Convert.ToDateTime(reader.GetValue(4).ToString()),
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
            var result = orders.ToList();

            // model doldurulduktan sonra file delete
            System.IO.File.Delete(fileName);

            try
            {
                _service.AddRangeAsync(_mapper.Map<IEnumerable<Order>>(orders));
            }
            catch (Exception ex)
            {

            }



            return result;
        }


        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetAllAsync();

            return View(_mapper.Map<IEnumerable<OrderDto>>(orders));
        }

    }
}