﻿using CrossCountrySkis.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CrossCountrySkis.Models
{
    public class SkiLengthFormModel
    {
        public int Age { get; set; }
        [Required]
        [Range(1, 300, ErrorMessage = "Please enter a valid length.")]
        public int Length { get; set; }
        public SkiType SkiType { get; set; }
    }
}
