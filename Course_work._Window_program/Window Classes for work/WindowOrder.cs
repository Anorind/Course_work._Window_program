using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_work._Window_program
{
    /// <summary>
    /// клас містить інформацію про замовлення вікна
    /// 
    /// class contains window ordering information
    /// </summary>
    internal class WindowOrder
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public decimal Width { get; set; }

        [Required]
        public decimal Height { get; set; }

        public string GlassColor { get; set; }

        public string FrameColor { get; set; }

        [Required]
        public string FrameMaterial { get; set; }

        [Required]
        public string GlassMaterial { get; set; }

        [Required]
        public int WindowChambers { get; set; }

        [Required]
        public int NumberOfSections { get; set; }
        [Required]
        public int NumberOfOpeningSections { get; set; }

        [Required]
        public string AddressOfOrder { get; set; }

        public DateTime? DateOfOrder { get; set; }

        [Required]
        public bool OrderCompleted { get; set; }

        [Required]
        public decimal TotalCash { get; set; }
    }

}
