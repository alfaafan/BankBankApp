using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Domain;

[Table("Users", Schema = "Users")]
[Index("Username", Name = "UQ__Users__536C85E4474564B1", IsUnique = true)]
[Index("Email", Name = "UQ__Users__A9D10534F2C0766C", IsUnique = true)]
public partial class User
{
	[Key]
	[Column("UserID")]
	public int UserId { get; set; }

	[StringLength(50)]
	[Unicode(false)]
	public string Username { get; set; } = null!;

	[StringLength(50)]
	[Unicode(false)]
	public string Email { get; set; } = null!;

	public string Password { get; set; } = null!;

	[StringLength(50)]
	public string FirstName { get; set; } = null!;

	[StringLength(50)]
	public string LastName { get; set; } = null!;

	[StringLength(20)]
	[Unicode(false)]
	public string Phone { get; set; } = null!;

	public DateOnly DateOfBirth { get; set; }

	public DateTime RegistrationDate { get; set; }

	public DateTime? LastLoginDate { get; set; }

	[InverseProperty("User")]
	public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

	[InverseProperty("User")]
	public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

	[ForeignKey("Username")]
	[InverseProperty("Usernames")]
	public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
