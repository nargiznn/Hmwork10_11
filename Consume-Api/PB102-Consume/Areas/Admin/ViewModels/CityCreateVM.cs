using System;
using System.ComponentModel.DataAnnotations;
using PB102_Consume.Models;

namespace PB102_Consume.Areas.Admin.ViewModels
{
	public class CityCreateVM
	{
        [Required]
        public string Name { get; set; }
        [Required]
        public int? CountryId { get; set; }
        public Country Country { get; set; }
    }
}

