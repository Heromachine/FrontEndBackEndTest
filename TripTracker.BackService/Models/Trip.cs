using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //Right click on project ->Editproject files->add line <PackageReference Include="System.ComponentModel.Annotations" Version="4.3.0"/>

namespace TripTracker.BackService.Models
{
    public class Trip
    {
        [Key] //Anotation to descript which variable(Id) is the Key So Entity Frame Work can use it as a Hash to find
        public int Id { get; set; }
        [Required] //When Adding a new Trip, This Annotation will error if the varable is missing upon Adding
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set;  }


    }
}
