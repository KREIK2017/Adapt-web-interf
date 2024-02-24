using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
	static void Main(string[] args)
	{
		UseThreadMethods();

		Task.Run(async () => await UseAsyncAwaitMethods());

		Console.ReadLine();
	}

	// 1. Thread

	static void UseThreadMethods()
	{
		Thread thread1 = new Thread(ThreadMethod1);
		Thread thread2 = new Thread(ThreadMethod2);
		Thread thread3 = new Thread(ThreadMethod3);

		thread1.Start();
		thread2.Start();
		thread3.Start();
	}

	static void ThreadMethod1()
	{
		Console.WriteLine("ThreadMethod1");
		int result = PerformComplexCalculation(5);
		Console.WriteLine("Результат ThreadMethod1: " + result);
	}

	static void ThreadMethod2()
	{
		Console.WriteLine("ThreadMethod2");
		int result = PerformComplexCalculation(7);
		Console.WriteLine("Результат ThreadMethod2: " + result);
	}

	static void ThreadMethod3()
	{
		Console.WriteLine("ThreadMethod3");
		int result = PerformComplexCalculation(3);
		Console.WriteLine("Результат ThreadMethod3: " + result);
	}

	static int PerformComplexCalculation(int number)
	{
		int result = 1;
		for (int i = 1; i <= number; i++)
		{
			result *= i;
			Thread.Sleep(100);
		}
		return result;
	}

	// 2. Async/Await

	static async Task UseAsyncAwaitMethods()
	{
		int result1 = await AsyncMethod1();
		Console.WriteLine(" AsyncMethod1: " + result1);
		int result2 = await AsyncMethod2();
		Console.WriteLine(" AsyncMethod2: " + result2);
		int result3 = await AsyncMethod3();
		Console.WriteLine(" AsyncMethod3: " + result3);
	}

	static async Task<int> AsyncMethod1()
	{
		Console.WriteLine("Початок виконання AsyncMethod1");
		int result = await PerformComplexCalculationAsync(5);
		Console.WriteLine("Завершення виконання AsyncMethod1");
		return result;
	}

	static async Task<int> AsyncMethod2()
	{
		Console.WriteLine("Початок виконання AsyncMethod2");
		int result = await PerformComplexCalculationAsync(7);
		Console.WriteLine("Завершення виконання AsyncMethod2");
		return result;
	}

	static async Task<int> AsyncMethod3()
	{
		Console.WriteLine("Початок виконання AsyncMethod3");
		int result = await PerformComplexCalculationAsync(3);
		Console.WriteLine("Завершення виконання AsyncMethod3");
		return result;
	}

	static async Task<int> PerformComplexCalculationAsync(int number)
	{
		if (number < 0)
			throw new ArgumentException("Number must be non-negative.", nameof(number));

		if (number == 0)
			return 1;

		await Task.Delay(100 * number);

		return await Task.Run(() => CalculateFactorial(number)); 
	}

	static int CalculateFactorial(int n)
	{
		if (n == 1)
			return 1;
		return n * CalculateFactorial(n - 1);
	}

}
