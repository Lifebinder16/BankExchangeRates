using System.ComponentModel.DataAnnotations;
using System;

namespace BankExchangeRates.Models
{
	public class ExchangeRateRequest
	{
		[DataType(DataType.Date)]
		public DateTime Date { get; set; } = DateTime.Now;

		public string CurrencyCode { get; set; } = String.Empty;
	}
}
