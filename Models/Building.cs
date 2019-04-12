using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models {

    [Table("buildings")]
    public class Building {
        [Key]
        public long id { get; set; }
        public long address_id {get; set;}
        public long customer_id {get;set;}
        public string full_name_admin_person {get; set;}
        public string email_admin_person {get;set;}
        public string phone_number_admin_person {get;set;}
        public string full_name_tech_person {get;set;}
        public string email_tech_person {get;set;}
        public string phone_number_tech_person {get;set;}
    }
}