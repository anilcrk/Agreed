using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreed.WebUI.DTOs
{
    public class CommissionDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Trasnsaction ID
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// İşlem Tipi
        /// </summary>
        public string ProcessType { get; set; }

        /// <summary>
        /// Sipraiş No
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// sipratiş tarihi
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Barkod
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// Komisyon oranı
        /// </summary>
        public double CommissionRate { get; set; }

        /// <summary>
        /// Ödeme Statüsü
        /// </summary>
        public string OdemeStatus { get; set; }

        /// <summary>
        /// İşlem Tarihi
        /// </summary>
        public DateTime ProcessDate { get; set; }

        /// <summary>
        /// Satıcı
        /// </summary>
        public string Seller { get; set; }

        /// <summary>
        /// Satıcı Cari Adı
        /// </summary>
        public string VendorCurrentName { get; set; }

        /// <summary>
        /// Ürün Adı
        /// </summary>
        public string ProductName { get; set; }



        /// <summary>
        /// TY Hakediş
        /// </summary>
        public double TYProgressPayment { get; set; }

        /// <summary>
        /// Satıcı Hakediş
        /// </summary>
        public double SellerProgressPayment { get; set; }

        /// <summary>
        /// Vade Süresi
        /// </summary>
        public int TermTime { get; set; }

        /// <summary>
        /// Vade Tarihi
        /// </summary>
        public DateTime TermDate { get; set; }

        /// <summary>
        /// Mutabık kalma tarihi
        /// </summary>
        public DateTime? AgreeDate { get; set; }

        /// <summary>
        /// Teslim Tarihi
        /// </summary>
        public DateTime Deliverydate { get; set; }

        /// <summary>
        /// Vade Tarihi
        /// </summary>
        public DateTime MaturityDate { get; set; }

        /// <summary>
        /// Komisyon Fatura No
        /// </summary>
        public string CommissionInvoiceNumber { get; set; }

        /// <summary>
        /// Toplam Tutar
        /// </summary>
        public double TotalAmount { get; set; }

        /// <summary>
        /// İsim
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Soyisim
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Kargoya veriliş tarihi
        /// </summary>
        public DateTime? ShippingDate { get; set; }
    }
}
