using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Domain;

[Table("CardTypes", Schema = "Users")]
public partial class CardType
{
	[Key]
	[Column("CardTypeID")]
	public int CardTypeId { get; set; }

	[StringLength(20)]
	[Unicode(false)]
	public string Type { get; set; } = null!;

	[InverseProperty("CardType")]
	public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
}
