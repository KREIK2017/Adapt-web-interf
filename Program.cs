using System;
using System.IO;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

class Program
{
	static async Task Main()
	{
		// 1. ������ � System.IO API: ���������, ����� � ������� �����
		string filePath = "example.txt";
		File.WriteAllText(filePath, "This is an example of text written to a file.");
		string content = File.ReadAllText(filePath);
		Console.WriteLine($"File content {filePath}:\n{content}");

		// 2. ������ � System.Net.Http API: ��������� HTTP-������
		using (HttpClient client = new HttpClient())
		{
			HttpResponseMessage response = await client.GetAsync("https://moodle3.chmnu.edu.ua/");
			string responseContent = await response.Content.ReadAsStringAsync();
			Console.WriteLine($"HTTP response from moodle3.chmnu.edu.ua:\n{responseContent}");
		}

		// 3. ������ � System.Linq API: ������������ LINQ ��� ���������� ��������
		int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		var evenNumbers = numbers.Where(n => n % 2 == 0);
		Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));

		// 4. ������ � System.Threading.Tasks API: ���������� ��������� ��������
		await Task.Delay(2000);
		Console.WriteLine("The pause is over. Continue executing the program.");

		// 5. ������ � System.Xml API: ������ � XML-����������
		string xmlString = "<book><title>Sample Book</title></book>";
		XDocument xmlDoc = XDocument.Parse(xmlString);
		string title = xmlDoc.Root?.Element("title")?.Value;
		Console.WriteLine($"Book title with XML: {title}");


		Console.ReadLine();
	}
}
