using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace shopLocalApi.Data.Entities
{
    [Table("item")]
    public class ItemEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("shopid")]
        public int ShopId { get; set; }

        [Column("ownerid")]
        public Guid OwnerId { get; set; }

        //public ShopEntity shop { get; set; }
    }
}
