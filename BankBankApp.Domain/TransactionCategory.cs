using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Domain;

[Table("TransactionCategories", Schema = "Transactions")]
public partial class TransactionCategory
{
	[Key]
	[Column("TransactionCategoryID")]
	public int TransactionCategoryId { get; set; }

	[StringLength(50)]
	[Unicode(false)]
	public string Name { get; set; } = null!;

	[InverseProperty("TransactionCategory")]
	public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
