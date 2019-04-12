using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models {

    [Table("interventions")]
    public class Intervention {
        [Key]
        public long id {get; set;}
        public long? author_id {get; set;}
        public long? customer_id {get;set;}
        public long? building_id {get; set;}
        public long? battery_id {get;set;}
        public long? column_id {get;set;}
        public long? elevator_id {get;set;}
        public long? employee_id {get;set;}
        public DateTime? intervention_start {get;set;}
        public DateTime? intervention_finish {get;set;}
        public string results {get;set;}
        public string report {get;set;}
        public string status {get;set;}
    }
}