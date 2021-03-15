using System;
using System.ComponentModel.DataAnnotations;
using Youlytical.Models.CRMModels;

namespace Youlytical.Models.CRMModels
{
    public class AddressModel
    {
        [Key]
        public int addrID { get; set; }
        public int ContactID { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string AddressType { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Address1 { get; set; }
        
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string State { get; set; }

        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Zip { get; set; }

        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Country { get; set; }
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Province { get; set; }

        public bool Primary { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime CreateDateTimeStamp { get; set; }
    }
}