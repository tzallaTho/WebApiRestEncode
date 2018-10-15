using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        [Range(0, 10000, ErrorMessage = "range excited", ErrorMessageResourceName = "error:", ErrorMessageResourceType = null)]
        [Required]
        public int NumberOfEmployees { get; set; }


        // [ForeignKey("customerId")]
        public ICollection<CustomerContact> customerContact { get; set; }
    }
}