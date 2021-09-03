using shopLocalCommonModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace shopLocalCommonModels.DbEntities
{
    [Table("shop")]
    public class ShopEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("ownerid")]
        public Guid OwnerId { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("streetaddress")]
        public string StreetAddress { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("state")]
        public string State { get; set; }

        [Column("zipcode")]
        public string ZipCode { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("latitude")]
        public string Latitude { get; set; }

        [Column("longitude")]
        public string Longitude { get; set; }

    }
}
