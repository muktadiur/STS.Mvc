using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STSMvc.Models.Entity
{
    [Serializable]
    public class User
    {
        [Required]
        [Key]
        [StringLength(50)]
        public string UserId { get; set; }
       
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int RoleId { get; set; }
        public bool Active { get; set; }
        public bool ReceiveEmailAlert { get; set; }

        [StringLength(100)]
        public string RoleDescription { get; set; }

        [StringLength(50)]
        public string GeoDescription { get; set; }

        [StringLength(100)]
        public string GeoCode { get; set; }

        public int? DefaultNav { get; set; }
    }
}