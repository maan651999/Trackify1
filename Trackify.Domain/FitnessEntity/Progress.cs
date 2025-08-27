using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trackify.Domain.Entities;

namespace Trackify.Domain.FitnessEntity
{
    public class Progress
    {
        [Key]
        public int ProgressId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Weight { get; set; } 
        [Required]
        public decimal BodyFat { get; set; } 
        [Required]
        public decimal Chest { get; set; } 
        [Required]
        public decimal Waist { get; set; } 
        [Required]
        public decimal Arms { get; set; }
        [Required]
        public decimal Legs { get; set; }
        public string PhotoPath { get; set; } = string.Empty;
        public User? User { get; set; }
    }
}
