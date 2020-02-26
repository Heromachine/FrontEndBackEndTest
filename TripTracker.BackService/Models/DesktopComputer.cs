using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TripTracker.BackService.Models
{
    public class DesktopComputer
    {

        [Key] //Anotation to descript which variable(Id) is the Key So Entity Frame Work can use it as a Hash to find
        public int Id { get; set; }
        [Required] //When Adding a new Trip, This Annotation will error if the varable is missing upon Adding
        public string Manufacturer { get; set; }

        [Required] //When Adding a new Trip, This Annotation will error if the varable is missing upon Adding
        public string TradeName { get; set; }

        [Required] 
        public string  ModelNumber{ get; set; }

        [Required]
        public string  ServieTag{ get; set; }

        [Required]
        public string  ComputerName{ get; set; }

        [Required]        
        public string  CameronCountyNumber{ get; set; }

        [Required]
        public string  Department{ get; set; }

        [Required]
        public string  DepartmentProgram{ get; set; }

        [Required]
        public string  OperatingSystem{ get; set; }

        [Required]
        public string Specifications { get; set; }

        [Required]
        public string  Notes{ get; set; }



    [Required]
        public DateTime DatePurchased { get; set; }
        [Required]
        public DateTime DateDestroyed { get; set; }
    }
}
