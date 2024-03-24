using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Domain;

[Table("Transactions", Schema = "Transactions")]
public partial class Transaction
{
	[Key]
	[Column("TransactionID")]
	public int TransactionId { get; set; }

	[Column("TransactionCategoryID")]
	public int TransactionCategoryId { get; set; }

	[Column("SourceAccountID")]
	public int SourceAccountId { get; set; }

	[Column("ReceiverAccountID")]
	public int? ReceiverAccountId { get; set; }

	[Column("BillID")]
	public int? BillId { get; set; }

	[Column(TypeName = "money")]
	public decimal Amount { get; set; }

	[StringLength(255)]
	[Unicode(false)]
	public string? Description { get; set; }

	public DateTime TransactionDate { get; set; }

	[StringLength(20)]
	[Unicode(false)]
	public string Status { get; set; } = null!;

	[ForeignKey("BillId")]
	[InverseProperty("Transactions")]
	public virtual Bill? Bill { get; set; }

	[ForeignKey("ReceiverAccountId")]
	[InverseProperty("TransactionReceiverAccounts")]
	public virtual Account? ReceiverAccount { get; set; }

	[ForeignKey("SourceAccountId")]
	[InverseProperty("TransactionSourceAccounts")]
	public virtual Account SourceAccount { get; set; } = null!;

	[ForeignKey("TransactionCategoryId")]
	[InverseProperty("Transactions")]
	public virtual TransactionCategory TransactionCategory { get; set; } = null!;
}
