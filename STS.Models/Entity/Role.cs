using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STSMvc.Models.Entity
{
    
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public int DefaultNav { get; set; }
    }
}