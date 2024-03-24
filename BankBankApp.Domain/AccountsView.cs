using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Domain;

[Keyless]
public partial class AccountsView
{
	[Column("UserID")]
	public int UserId { get; set; }

	[StringLength(50)]
	[Unicode(false)]
	public string Username { get; set; } = null!;

	[StringLength(20)]
	[Unicode(false)]
	public string AccountNumber { get; set; } = null!;

	[StringLength(20)]
	[Unicode(false)]
	public string AccountType { get; set; } = null!;

	[Column(TypeName = "money")]
	public decimal Balance { get; set; }

	[StringLength(3)]
	[Unicode(false)]
	public string Currency { get; set; } = null!;

	[StringLength(20)]
	[Unicode(false)]
	public string Status { get; set; } = null!;
}
