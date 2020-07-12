using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DotnetCoreCrud.Domain.Entities
{
    [DataContract]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public Guid Guid { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public decimal UnitValue { get; set; }
        [DataMember]
        public float Amount { get; set; }
        [DataMember]
        public int Unity { get; set; }
        [DataMember]
        [ForeignKey("category")]
        public Category Category { get; set; }
    }
}
