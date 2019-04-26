using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models {

    [Table("adresses")]
    public class Building {
        [Key]
        public long id { get; set; }
        public string address_type {get; set;}
        public string status {get;set;}
        public string entity {get; set;}
        public string number_street {get;set;}
        public string city {get;set;}
        public string postal_code {get;set;}
        public string country {get;set;}
        public string notes {get;set;}
        
    }
}