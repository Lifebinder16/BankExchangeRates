using System.ComponentModel.DataAnnotations;
using System;

namespace BankExchangeRates.Models
{
	/// <summary>
	/// Запрос к API Банка России
	/// </summary>
	public class ExchangeRateRequest
	{
		/// <summary>
		/// Дата, на которую требуется получить данные о валюте в формате YYYY-MM-dd (например: 2025-05-14)
		/// </summary>
		[DataType(DataType.Date)]
		public DateTime Date { get; set; } = DateTime.Now;

		/// <summary>
		/// Буквенный код валюты (например: USD)
		/// </summary>
		public string CurrencyCode { get; set; } = String.Empty;
	}
}
