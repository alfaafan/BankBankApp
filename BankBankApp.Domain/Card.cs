using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Domain;

[Table("Cards", Schema = "Users")]
public partial class Card
{
	[Key]
	[Column("CardID")]
	public int CardId { get; set; }

	[Column("UserID")]
	public int UserId { get; set; }

	[StringLength(20)]
	[Unicode(false)]
	public string CardNumber { get; set; } = null!;

	[Column("CardTypeID")]
	public int CardTypeId { get; set; }

	public DateTime ExpirationDate { get; set; }

	[StringLength(10)]
	[Unicode(false)]
	public string Status { get; set; } = null!;

	[ForeignKey("CardTypeId")]
	[InverseProperty("Cards")]
	public virtual CardType CardType { get; set; } = null!;

	[ForeignKey("UserId")]
	[InverseProperty("Cards")]
	public virtual User User { get; set; } = null!;
}
