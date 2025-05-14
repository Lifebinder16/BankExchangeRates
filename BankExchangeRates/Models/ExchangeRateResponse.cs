using System;

namespace BankExchangeRates.Models
{
	public class ExchangeRateResponse
	{
		public string Id { get; set; }
		public DateTime Date { get; set; }
		public int NumCode { get; set; }
		public string CharCode { get; set; }
		public int Nominal { get; set; }
		public string Name { get; set; }
		public decimal Value { get; set; }
		public decimal VunitRate { get; set; }
	}
}
