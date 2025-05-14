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
		/// Числовой код валюты
		/// </summary>
		public int NumCode { get; set; }
		/// <summary>
		/// Буквенный код валюты
		/// </summary>
		public string CharCode { get; set; }
		/// <summary>
		/// Номинал
		/// </summary>
		public int Nominal { get; set; }
		/// <summary>
		/// Наименование валюты
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Значение Value
		/// </summary>
		public decimal Value { get; set; }
		/// <summary>
		/// Значение VunitRate
		/// </summary>
		public decimal VunitRate { get; set; }
	}
}
