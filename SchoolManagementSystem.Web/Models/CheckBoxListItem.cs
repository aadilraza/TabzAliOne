using System.Collections.Generic;

namespace SchoolManagementSystem.Web.Models
{
    public class CheckBoxListItem
    {
        /// <summary>
        /// Integer value of a checkbox
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// String name of a checkbox
        /// </summary>
        public string Display { get; set; }
        /// <summary>
        /// Object of html tags to be applied to checkbox, e.g.: 'new { tagName = "tagValue" }'
        /// </summary>
        public bool IsChecked { get; set; }
    }
}