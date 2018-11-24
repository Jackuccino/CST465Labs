using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_4.Models
{
    public class ComputerModel
    {
        public static readonly List<string> OSTypes =
            new List<string> { "iOS", "Windows", "Linux" };

        [Required]
        [MaxLength(20)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
        [RegularExpression("\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}", 
            ErrorMessage = "IP Address must be one to three digits before and after each of the three dots. Ex. 127.0.0.1")]
        [DisplayName("IP Address")]
        public string IPAddress { get; set; }
        [DisplayName("Location")]
        public string Location { get; set; }
        [Required]
        [UIHint("OSDropdown")]
        [DisplayName("OS")]
        public string OS { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required]
        [Range(1, 4)]
        [DisplayName("Supported Monitors")]
        public int? SupportedMonitors { get; set; }
    }
}
