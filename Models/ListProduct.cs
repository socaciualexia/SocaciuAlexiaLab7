using SQLite;
using SQLiteNetExtensions.Attributes;

namespace SocaciuAlexiaLab7.Models
{
    internal class ListProduct
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(ShopList))]
        public int ShopListID { get; set; } 

        [ForeignKey(typeof(Product))]
        public int ProductID { get; set; }

        [ManyToOne]
        public ShopList ShopList { get; set; }

        [ManyToOne]
        public Product Product { get; set; }
    }
}
