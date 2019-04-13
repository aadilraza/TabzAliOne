using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Web.Models.Person
{
    public class PersonDetailsViewModel:PersonViewModel
    {
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public IEnumerable<SelectListItem> Cities { get; set; }
        public int CityId { get; set; }
    }
}