using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetCoreCrud.Domain.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }
        public string Description { get; set; }
        public decimal UnitValue { get; set; }
        public float Amount { get; set; }
        public int Unity { get; set; }
        [ForeignKey("category")]
        public Category Category { get; set; }
    }
}
