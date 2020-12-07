using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PXUK16.Web.Models
{
    public class UpdateManafactory
    {

        public int ManufactoryId { get; set; }

        [Display(Name = "Manafactory Name")]
        [Required(ErrorMessage = "Manafactory Name is required.")]
        public string Name { get; set; }
    }
}
