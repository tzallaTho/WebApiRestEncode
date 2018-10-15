using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class CustomerContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string firstName { get; set; }

        [MaxLength(100)]
        [Required]
        public string lastName { get; set; }

        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required]
        public string email { get; set; }


        public int customerId { get; set; }

        public Customer customer { get; set; }
    }
}