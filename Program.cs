using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
	static HttpClient httpClient = new HttpClient();
	static async Task Main()
	{
		APIClient apiClient = new APIClient();
		ResponseModel<string> response = await apiClient.GetRandomText();

		// Перевірка, чи відповідь успішна
		if (response.HttpStatusCode == 200)
		{
			Console.WriteLine($"Message: {response.Message}");
			Console.WriteLine($"HTTP Status Code: {response.HttpStatusCode}");

			// Виведення отриманих даних з API
			if (response.Data != null)
			{
				foreach (var data in response.Data)
				{
					Console.WriteLine($"Data from API: {data}");
				}
			}
			else
			{
				Console.WriteLine("No data received from API.");
			}
		}
		else
		{
			Console.WriteLine($"Error: {response.Message}");
			Console.WriteLine($"HTTP Status Code: {response.HttpStatusCode}");
		}

	}
}
