using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Domain;

[Table("AccountTypes", Schema = "Users")]
public partial class AccountType
{
	[Key]
	[Column("AccountTypeID")]
	public int AccountTypeId { get; set; }

	[StringLength(20)]
	[Unicode(false)]
	public string Name { get; set; } = null!;

	[InverseProperty("AccountType")]
	public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
