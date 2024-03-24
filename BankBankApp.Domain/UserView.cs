using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Domain;

[Keyless]
public partial class UserView
{
	[Column("UserID")]
	public int UserId { get; set; }

	[StringLength(50)]
	[Unicode(false)]
	public string Username { get; set; } = null!;

	public string Password { get; set; } = null!;

	[StringLength(50)]
	[Unicode(false)]
	public string Email { get; set; } = null!;

	[StringLength(50)]
	public string FirstName { get; set; } = null!;

	[StringLength(50)]
	public string LastName { get; set; } = null!;

	[StringLength(20)]
	[Unicode(false)]
	public string Phone { get; set; } = null!;

	public DateOnly DateOfBirth { get; set; }

	[StringLength(20)]
	[Unicode(false)]
	public string AccountNumber { get; set; } = null!;

	[Column("AccountID")]
	public int AccountId { get; set; }

	[StringLength(20)]
	[Unicode(false)]
	public string CardNumber { get; set; } = null!;

	public DateTime ExpirationDate { get; set; }

	[Column(TypeName = "money")]
	public decimal Balance { get; set; }

	[StringLength(20)]
	[Unicode(false)]
	public string Status { get; set; } = null!;

	public DateTime? LastLoginDate { get; set; }
}
