using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication8.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID { get; set; }
        [Display(Name = "Email")]
        [EmailAddress]
        public string userEmail { get; set; }
        [Display(Name = "Password")]
        [MaxLength(16)]
        public string userPassword { get; set; }
        [Display(Name = "First Name")]
        [MaxLength(16)]
        public string userFirstName { get; set; }
        [Display(Name = "Last Name")]
        [MaxLength(16)]
        public string userLastName { get; set; }
    }
}