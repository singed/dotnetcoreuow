using System.Collections.Generic;
using Repository.Pattern.EfCore;

namespace Northwind.DataAccess.Models
{
    public class Category :Entity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}