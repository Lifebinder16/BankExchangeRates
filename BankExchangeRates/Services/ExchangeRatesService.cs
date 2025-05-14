using BankExchangeRates.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System;
using System.Linq;

namespace BankExchangeRates.Services
{
	public class ExchangeRatesService
	{

		private readonly IHttpClientFactory _httpClientFactory;
		private const string CbrApiUrl = "https://www.cbr.ru/scripts/XML_daily.asp";

		/// <summary>
		/// Конструктор класса
		/// </summary>
		/// <param name="httpClientFactory">Интерфейс для управления экземплярами HttpClient</param>
		public ExchangeRatesService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		/// <summary>
		/// Получает коллекцию с данными о валютах с сайта Банка России
		/// </summary>
		/// <param name="date">Дата (если не задана, то сегодня)</param>
		/// <param name="currencyCode">Буквенный код валюты (если не задан, то вернёт информацию о всех валютах)</param>
		/// <returns>Коллекция с данными о валютах</returns>
		public async Task<IEnumerable<ExchangeRateResponse>> GetCbrCurrencyRate(DateTime date, string currencyCode)
		{
			var xmlDoc = await GetCbrCurrencyRateAsXml(date, currencyCode);
			var valCursNode = xmlDoc.SelectSingleNode($"ValCurs");
			var result = new List<ExchangeRateResponse>();
			var childNodes = valCursNode.ChildNodes;
			foreach (XmlNode node in childNodes)
			{
				var valuteCode = node.SelectSingleNode("CharCode").InnerText;

				// Если точно задана валюта, то возвращаем только её
				if (currencyCode != String.Empty && valuteCode != currencyCode)
					continue;

				var valuteRate = new ExchangeRateResponse
				{
					Id = node.Attributes.GetNamedItem("ID").InnerText,
					Date = date,
					NumCode = int.Parse(node.SelectSingleNode("NumCode").InnerText),
					CharCode = valuteCode,
					Nominal = int.Parse(node.SelectSingleNode("Nominal").InnerText),
					Name = node.SelectSingleNode("Name").InnerText,
					Value = decimal.Parse(node.SelectSingleNode("Value").InnerText),
					VunitRate = decimal.Parse(node.SelectSingleNode("VunitRate").InnerText)
				};
				result.Add(valuteRate);
			}
			return result;
		}

		private async Task<XmlDocument> GetCbrCurrencyRateAsXml(DateTime date, string currencyCode)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"{CbrApiUrl}?date_req={date:dd/MM/yyyy}");

			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			response.EnsureSuccessStatusCode();

			var buffer = await response.Content.ReadAsByteArrayAsync();
			var byteArray = buffer.ToArray();
			var xml = Encoding.GetEncoding(1251).GetString(byteArray, 0, byteArray.Length);
			var doc = new XmlDocument();
			doc.LoadXml(xml);
			return doc;
		}

	}
}
