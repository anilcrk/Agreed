using System;
using System.Collections.Generic;
using System.Text;

namespace Agreed.Core.Entities
{
    public class Cargo
    {
        public int CompanyId { get; set; }
        public int Id { get; set; }

        /// <summary>
        /// Satıcı Id
        /// </summary>
        public string SellerID { get; set; }

        /// <summary>
        /// Gönderi Ücreti (KDV Dahil)
        /// </summary>
        public double ShipmentFee { get; set; }

        /// <summary>
        /// desi
        /// </summary>
        public string Desi { get; set; }

        /// <summary>
        /// Satıcı İsmi
        /// </summary>
        public string SellerName { get; set; }

        /// <summary>
        /// Sipariş No
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// Gönderi / İade
        /// </summary>
        public string ShipmentIsReturns { get; set; }

        /// <summary>
        /// Gönderi / İade Kodu
        /// </summary>
        public string ShipmentIsReturnCode { get; set; }

        /// <summary>
        /// Kargo Firması
        /// </summary>
        public string CargoCompany { get; set; }

        /// <summary>
        /// Sipariş Tarihi
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Sevk Tarihi
        /// </summary>
        public DateTime ShipmentDate { get; set; }

        /// <summary>
        /// Sipariş Tutarı
        /// </summary>
        public double OrderAmount { get; set; }

        /// <summary>
        /// Minimum kampanya baremi
        /// </summary>
        public string MinCampaignScale { get; set; }

        /// <summary>
        /// Ürün adedi
        /// </summary>
        public string NumberOfProducts { get; set; }

        /// <summary>
        /// Butik Id
        /// </summary>
        public string BoutiqueId { get; set; }

        public virtual Company Company { get; set; }
    }
}
