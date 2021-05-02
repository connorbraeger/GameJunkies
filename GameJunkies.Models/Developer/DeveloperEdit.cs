﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.Developer
{
    public class DeveloperEdit
    {
        [Required]
        public int? DeveloperId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CompanySize { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public float? Rating { get; set; }
    }
}
