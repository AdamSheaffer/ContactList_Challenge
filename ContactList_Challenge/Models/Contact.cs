using System;
using System.ComponentModel.DataAnnotations;

namespace ContactList_Challenge.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
    }
}