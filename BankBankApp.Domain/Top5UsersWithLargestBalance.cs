using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Domain;

[Keyless]
public partial class Top5UsersWithLargestBalance
{
	[Column("UserID")]
	public int UserId { get; set; }

	[StringLength(50)]
	[Unicode(false)]
	public string Username { get; set; } = null!;

	[StringLength(50)]
	[Unicode(false)]
	public string Email { get; set; } = null!;

	[Column(TypeName = "money")]
	public decimal Balance { get; set; }
}
