using BankBankApp.Service.DTOs;
using BankBankApp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankBankApp.API.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CardsController : ControllerBase
	{
		private readonly ICardService _cardService;
		public CardsController(ICardService cardService)
		{
			_cardService = cardService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var cards = await _cardService.GetAll();
				if (cards == null || cards.Count() == 0)
				{
					return NotFound();
				}
				return Ok(cards);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				var card = await _cardService.Get(id);
				if (card == null)
				{
					return NotFound();
				}
				return Ok(card);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("number/{cardNumber}")]
		public async Task<IActionResult> GetByCardNumber(string cardNumber)
		{
			try
			{
				var card = await _cardService.GetByCardNumber(cardNumber);
				if (card == null)
				{
					return NotFound();
				}
				return Ok(card);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post(CardDTO card)
		{
			try
			{
				var result = await _cardService.Add(card);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}
