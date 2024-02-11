using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_work._Window_program
{
    /// <summary>
    /// Клас містить інформацію про матеріали
    /// 
    /// A class that contains information about materials 
    /// </summary>
    internal class Material
    {
        [Key]
        public int MaterialId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Name { get; set; }

        public string Color { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public string Description { get; set; }
    }
}
