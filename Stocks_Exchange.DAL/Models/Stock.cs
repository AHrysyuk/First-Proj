using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stocks_Exchange
{
    [Table("STOCKS")]
    public partial class Stock
    {
        [Column("ID")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Column("NAME")]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [Column("COMPANY")]
        [MaxLength(100)]
        [Required]
        public string Company { get; set; }
        [Column("EXCHANGE_ID")]
        [ForeignKey("Exchange")]
        public int ExchangeId { get; set; }

        public virtual Exchange Exchange { get; set; }

    }
}
