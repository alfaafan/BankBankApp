using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Domain;

[Keyless]
public partial class UserTransactionHistory
{
	[Column("TransactionID")]
	public int TransactionId { get; set; }

	[StringLength(50)]
	[Unicode(false)]
	public string TransactionCategory { get; set; } = null!;

	[StringLength(50)]
	[Unicode(false)]
	public string Username { get; set; } = null!;

	[StringLength(20)]
	[Unicode(false)]
	public string SourceAccountNumber { get; set; } = null!;

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

	[Column("UserID")]
	public int UserId { get; set; }

	[StringLength(20)]
	[Unicode(false)]
	public string? ReceiverAccountNumber { get; set; }
}
