using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Domain;

[Table("Bills", Schema = "Transactions")]
public partial class Bill
{
	[Key]
	[Column("BillID")]
	public int BillId { get; set; }

	[Column("BillerID")]
	public int BillerId { get; set; }

	[Column("AccountID")]
	public int AccountId { get; set; }

	[Column(TypeName = "money")]
	public decimal Amount { get; set; }

	public DateTime DueDate { get; set; }

	[StringLength(20)]
	[Unicode(false)]
	public string Status { get; set; } = null!;

	[ForeignKey("AccountId")]
	[InverseProperty("Bills")]
	public virtual Account Account { get; set; } = null!;

	[ForeignKey("BillerId")]
	[InverseProperty("Bills")]
	public virtual Biller Biller { get; set; } = null!;

	[InverseProperty("Bill")]
	public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
