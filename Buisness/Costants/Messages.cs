using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Costants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInValid = "Ürün adı geçersiz";
        public static string MaintTenanceTime = "Sistem Bakımda";
        internal static string ProductListed;
        public static string Product;

        public static string ProductNotId;

        public static string ProductEmpty = "Ürün Boş";
        public static string CategoryCountMuch = "Ürün adı ile çok sayıda kategori var";

        public static string ProdNameAlready = "Aynı ada sahip ürün var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
    }
}
