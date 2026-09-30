using System;

class TTriangle
{
	private double a;
	private double b;
	private double c;

	public TTriangle()
	{
		a = 0;
		b = 0;
		c = 0;
	}

	public TTriangle(double a, double b, double c)
	{
		this.a = a;
		this.b = b;
		this.c = c;
	}

	public TTriangle(TTriangle NnTTriangle)
	{
		a = NnTTriangle.a;
		b = NnTTriangle.b;
		c = NnTTriangle.c;
	}

	public override string ToString()
	{
		return $"a = {a}, b = {b}, c = {c}";
	}

	public virtual void Input()
	{
		string[] abc = Console.ReadLine().Split(' ');
		while (abc.Length < 3 || !double.TryParse(abc[0], out a) || !double.TryParse(abc[1], out b) || !double.TryParse(abc[2], out c))
		{
			Console.Write("ні\n");
			abc = Console.ReadLine().Split(' ');
		}
		a = double.Parse(abc[0]);
		b = double.Parse(abc[1]);
		c = double.Parse(abc[2]);
	}

	public double CalculateArea()
	{
		double p = (a + b + c) / 2;
		return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
	}

	public static bool operator ==(TTriangle t1, TTriangle t2)
	{
		if (ReferenceEquals(t1, t2))
		{
			return true;
		}

		if (t1 is null || t2 is null)
		{
			return false;
		}

		return Math.Abs(t1.CalculateArea() - t2.CalculateArea()) == 0;
	}

	public static bool operator !=(TTriangle t1, TTriangle t2)
	{
		return !(t1 == t2);
	}

	public static TTriangle operator *(TTriangle triangle, double number)
	{
		return new TTriangle(
			triangle.a * number,
			triangle.b * number,
			triangle.c * number
		);
	}

	public static TTriangle operator *(double number, TTriangle triangle)
	{
		return triangle * number;
	}

	static void Main()
	{
		TTriangle t1 = new TTriangle();

		Console.WriteLine("введіть сторони трикутника");
		t1.Input();

		Console.WriteLine($"перевірка виводу {t1.ToString()}");
		Console.WriteLine($"площа: {t1.CalculateArea()}");

		TTriangle t2 = new TTriangle(3, 3, 3);

		Console.WriteLine($"Мій Трикутник {t2.ToString()}");
		Console.WriteLine($"Площа: {t2.CalculateArea()}");

		TTriangle t3 = new TTriangle(t2);

		Console.WriteLine($"Третій трикутник (копія мого,крутого,рикутника): {t3.ToString()}");

		Console.WriteLine("Порівняння");

		if (t1 == t2)
		{
			Console.WriteLine("t1 і t2 рівні");
		}
		else
		{
			Console.WriteLine("Ваш трикутник не такий крутий як мій");
		}

		Console.WriteLine("Порівняння 2");

		if (t1 != t3)
		{
			Console.WriteLine("ваш трикутник не крутіший навіть за копію мого");
		}
		else
		{
			Console.WriteLine("t1 і t3 рівні");
		}
		Console.WriteLine("Два ваших трикутника🤢😪:");
		Console.WriteLine((t1 * 2).ToString());
		Console.WriteLine("три моїх трикутника🤩🥰:");
		Console.WriteLine((t2 * 3).ToString());

		Console.WriteLine("Призма");
		TTrianglePrizm p1 = new TTrianglePrizm(3, 4, 5, 10);
		Console.WriteLine($"Призма: {p1.ToString()}");
		Console.WriteLine($"Площа основи: {p1.CalculateArea()}");
		Console.WriteLine($"Об'єм призми: {p1.CalculateVolume()}");
		TTrianglePrizm p2 = new TTrianglePrizm();
		Console.WriteLine("\nВведіть сторони основи призми:");
		p2.Input();
		Console.WriteLine($"Призма після введення: {p2.ToString()}");
		Console.WriteLine($"Площа основи: {p2.CalculateArea()}");
		Console.WriteLine($"Об'єм призми: {p2.CalculateVolume()}");
		TTrianglePrizm p3 = new TTrianglePrizm(p1);
		Console.WriteLine($"Копія призми: {p3.ToString()}");
		Console.WriteLine($"Об'єм копії: {p3.CalculateVolume()}");
	}

	class TTrianglePrizm : TTriangle
	{
		private double height;

		public TTrianglePrizm() : base()
		{
			height = 0;
		}

		public TTrianglePrizm(double a, double b, double c, double height) : base(a, b, c)
		{
			this.height = height;
		}

		public TTrianglePrizm(TTrianglePrizm NnTTrianglePrizm)
		{
			height = NnTTrianglePrizm.height;
		}

		public override void Input()
		{
			base.Input();

			Console.Write("введіть висоту призми\n");
			while (!double.TryParse(Console.ReadLine(), out height))
			{
				Console.Write("ні\n");
			}
		}

		public double CalculateVolume()
		{
			return CalculateArea() * height;
		}

		public override string ToString()
		{
			return $"{base.ToString()}, висота {height}";
		}
	}
}