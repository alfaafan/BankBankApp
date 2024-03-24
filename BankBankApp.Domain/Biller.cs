using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Domain;

[Table("Billers", Schema = "Transactions")]
public partial class Biller
{
	[Key]
	[Column("BillerID")]
	public int BillerId { get; set; }

	[StringLength(50)]
	[Unicode(false)]
	public string BillerName { get; set; } = null!;

	[StringLength(100)]
	[Unicode(false)]
	public string BillerAccountNumber { get; set; } = null!;

	[InverseProperty("Biller")]
	public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
