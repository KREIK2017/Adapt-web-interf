using System;
using System.Reflection;

public class MyClass
{
	// Поля класу
	private int _privateField;
	public string PublicField;
	internal double InternalField;
	protected bool ProtectedField;
	protected internal decimal ProtectedInternalField;

	// Конструктор класу
	public MyClass(int privateField, string publicField, double internalField,
				   bool protectedField, decimal protectedInternalField)
	{
		_privateField = privateField;
		PublicField = publicField;
		InternalField = internalField;
		ProtectedField = protectedField;
		ProtectedInternalField = protectedInternalField;
	}

	// Методи класу
	public void Method1()
	{
		Console.WriteLine("Виклик методу Method1");
	}

	public int Method2(int value)
	{
		Console.WriteLine($"Виклик методу Method2 з аргументом {value}");
		return value * 2;
	}

	public string Method3(string message)
	{
		Console.WriteLine($"Виклик методу Method3 з аргументом {message}");
		return message.ToUpper();
	}

	static void Main()
	{
		// Приклад роботи з Type і TypeInfo
		Type myType = typeof(MyClass);
		TypeInfo typeInfo = myType.GetTypeInfo();
		Console.WriteLine("///// 2 /////");
		Console.WriteLine($"Type: {myType}");
		Console.WriteLine($"Type.FullName: {typeInfo.FullName}");

		// Приклад роботи з MemberInfo

		MemberInfo[] members = myType.GetMembers();
		Console.WriteLine("///// 3 /////");

		Console.WriteLine("\nMembers:");
		foreach (MemberInfo member in members)
		{
			Console.WriteLine($"{member.MemberType}: {member.Name}");
		}

		// Приклад роботи з FieldInfo
		Console.WriteLine("///// 4 /////");

		FieldInfo[] fields = myType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
		Console.WriteLine("\nFields:");
		foreach (FieldInfo field in fields)
		{
			Console.WriteLine($"{field.FieldType} {field.Name}");
		}

		// Приклад роботи з MethodInfo
		Console.WriteLine("///// 5 /////");

		MethodInfo method = myType.GetMethod("Method2");
		Console.WriteLine($"\nMethod: {method.Name}");
		object instance = Activator.CreateInstance(myType, 10, "test", 3.14, true, 5.67m);
		object result = method.Invoke(instance, new object[] { 5 });
		Console.WriteLine($"Result: {result}");

		Console.ReadLine();
	}
}
