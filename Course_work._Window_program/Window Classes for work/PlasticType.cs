using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Course_work._Window_program
{
    internal class PlasticType
    {
        [Key]
        public int PlasticTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Cost { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }

        [ForeignKey("Material")]
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }

        public PlasticType() { }

        public PlasticType(string name, decimal price, string color, string description = null)
        {
            Name = name;
            Cost = price;
            Color = color;

            Material = new Material
            {
                Category = "frame material",
                Name = this.Name,
                Color = this.Color,
                Cost = this.Cost
            };
        }
    }
}
