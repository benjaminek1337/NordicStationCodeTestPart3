using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordicStationCodeTestPart3.Models
{
    public class CreditCard
    {
        [Key]
        public int CreditCardID { get; set; }

        [Required(ErrorMessage = "Card type is required")]
        [Display(Name = "Card Type")]
        [MaxLength(50)]
        public string CardType { get; set; }

        [Required(ErrorMessage = "Card number is required")]
        [Display(Name = "Card Number")]
        [MaxLength(25)]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Expiration month is required")]
        [Display(Name = "Expiration month")]
        public byte ExpMonth { get; set; }

        [Required(ErrorMessage = "Expiration year is required")]
        [Display(Name = "Expiration year")]
        public short ExpYear { get; set; }

        [Required(ErrorMessage = "The modified date is required")]
        [Display(Name = "Date modified")]
        public DateTime ModifiedDate { get; set; }
    }
}
