using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Domain;

[Table("Accounts", Schema = "Users")]
[Index("AccountNumber", Name = "unique_account_number", IsUnique = true)]
public partial class Account
{
	[Key]
	[Column("AccountID")]
	public int AccountId { get; set; }

	[Column("UserID")]
	public int UserId { get; set; }

	[StringLength(20)]
	[Unicode(false)]
	public string AccountNumber { get; set; } = null!;

	[Column("AccountTypeID")]
	public int AccountTypeId { get; set; }

	[Column(TypeName = "money")]
	public decimal Balance { get; set; }

	[Column(TypeName = "decimal(5, 2)")]
	public decimal? InterestRate { get; set; }

	[Column(TypeName = "decimal(18, 2)")]
	public decimal? CreditLimit { get; set; }

	[StringLength(3)]
	[Unicode(false)]
	public string Currency { get; set; } = null!;

	[StringLength(20)]
	[Unicode(false)]
	public string Status { get; set; } = null!;

	[ForeignKey("AccountTypeId")]
	[InverseProperty("Accounts")]
	public virtual AccountType AccountType { get; set; } = null!;

	[InverseProperty("Account")]
	public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

	[InverseProperty("ReceiverAccount")]
	public virtual ICollection<Transaction> TransactionReceiverAccounts { get; set; } = new List<Transaction>();

	[InverseProperty("SourceAccount")]
	public virtual ICollection<Transaction> TransactionSourceAccounts { get; set; } = new List<Transaction>();

	[ForeignKey("UserId")]
	[InverseProperty("Accounts")]
	public virtual User User { get; set; } = null!;
}
