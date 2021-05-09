using Agreed.Core.Entities;
using Agreed.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agreed.WebUI.DTOs
{
    public class OrderDto
    {
        public int CompanyId { get; set; }
        public string Barcode { get; set; }
        public string PackageNumber { get; set; }
        public string CargoCompany { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? CargoDeliveryDate { get; set; }

        /// <summary>
        /// Kargo Kodu
        /// </summary>
        public string CargoCode { get; set; }

        /// <summary>
        /// Sipariş Numarası
        /// </summary>
        [Required]
        public string OrderNumber { get; set; }
        public string Receiver { get; set; }

        /// <summary>
        /// Teslimat Adresi
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// Ürün Adı
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Fatura Adresi
        /// </summary>
        public string BillingAddress { get; set; }

        /// <summary>
        /// Sipatiş Statüsü
        /// </summary>
        public string OrderStatus { get; set; }

        /// <summary>
        /// E-Posta
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Komisyon Oranı
        /// </summary>
        public double CommissionRate { get; set; }

        /// <summary>
        /// Brand
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Stok Kodu
        /// </summary>
        public string StockCode { get; set; }

        /// <summary>
        /// Adet
        /// </summary>
        public int Piece { get; set; }

        /// <summary>
        /// Birim Fiyatı
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Satış Tutarı
        /// </summary>
        public decimal SalesAmount { get; set; }

        /// <summary>
        /// İndirim Tutarı
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Faturalacak Tutar
        /// </summary>
        public decimal AmountTobeBilled { get; set; }

        /// <summary>
        /// Butik Numarası
        /// </summary>
        public string BoutiqueNumber { get; set; }
    }
}
