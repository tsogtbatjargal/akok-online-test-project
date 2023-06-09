﻿using System.ComponentModel.DataAnnotations;

namespace AKOK_BlazorServer.Models
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

    }
}
