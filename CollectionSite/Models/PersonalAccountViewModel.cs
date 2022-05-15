﻿using System.ComponentModel.DataAnnotations;

namespace CollectionSite.Models
{
    public class PersonalAccountViewModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }


    }
}
