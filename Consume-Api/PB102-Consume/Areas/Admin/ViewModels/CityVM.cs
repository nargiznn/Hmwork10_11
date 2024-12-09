using System;
using PB102_Consume.Models;

namespace PB102_Consume.Areas.Admin.ViewModels
{
	public class CityVM
	{

        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; } 
        

    }
}

