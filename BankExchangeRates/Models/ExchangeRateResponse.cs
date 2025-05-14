using System;

namespace BankExchangeRates.Models
{
	/// <summary>
	/// Ответ от API Банка России
	/// </summary>
	public class ExchangeRateResponse
	{
		/// <summary>
		/// ID валюты
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// Дата
		/// </summary>
		public DateTime Date { get; set; }
		/// <summary>
		/// ISO Цифровой код валюты
		/// </summary>
		public int NumCode { get; set; }
		/// <summary>
		/// ISO Символьный код валюты
		/// </summary>
		public string CharCode { get; set; }
		/// <summary>
		/// Номинал
		/// </summary>
		public int Nominal { get; set; }
		/// <summary>
		/// Название валюты
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Курс
		/// </summary>
		public decimal Value { get; set; }
		/// <summary>
		/// Курс за 1 единицу валюты
		/// </summary>
		public decimal VunitRate { get; set; }
	}
}
