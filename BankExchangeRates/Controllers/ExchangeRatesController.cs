using BankExchangeRates.Models;
using BankExchangeRates.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankExchangeRates.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ExchangeRatesController : ControllerBase
	{

		private readonly ILogger<ExchangeRatesController> _logger;
		private readonly ExchangeRatesService _service;

		public ExchangeRatesController(ILogger<ExchangeRatesController> logger, ExchangeRatesService service)
		{
			_logger = logger;
			_service = service;
		}
		 
		/// <summary>
		/// Возвращает коллекцию валют и информацию о них с сайта Банка России
		/// </summary>
		/// <param name="request">Параметры запроса</param>
		/// <returns>Возвращает коллекцию валют</returns>
		[HttpGet]
		public async Task<ActionResult<List<ExchangeRateResponse>>> GetCurrencyRate([FromQuery] ExchangeRateRequest request)
		{
			try
			{				
				var list = await _service.GetCbrCurrencyRate(request.Date, request.CurrencyCode);				
				if (list.Any())
				{
					return Ok(list);
				}
				else
				{
					return NoContent();
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Ошибка при получении курса валюты: {ex.Message}");
			}
		}	

	}
}
