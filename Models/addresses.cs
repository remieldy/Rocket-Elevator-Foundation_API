using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models {

    [Table("addresses")]
    public class Addresses {
        [Key]
        public long id { get; set; }
        public string city {get;set;}
    }
}