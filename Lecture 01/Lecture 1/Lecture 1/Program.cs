namespace Lecture_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Expr e1 = new Add(new Var("x"), new Sub(new CstI (1), new CstI (5)));
			System.Console.WriteLine(e1.ToString());
			Expr e2 = new Sub(new Var("x"), new Var("y"));
			System.Console.WriteLine(e2.ToString());
			Expr e3 = new Mul(new Var("x"), new Var("y"));
			System.Console.WriteLine(e3.ToString());
		}
    }

	public abstract class Expr { }

	public class CstI : Expr
	{
		int x;

		public CstI(int y) { x = y; }

		public override string ToString()
		{
			return $"{x}";
		}
	}

	public class Var : Expr
	{
		string v;

		public Var(string str) { v = str; }

		public override string ToString()
		{
			return v;
		}
	}

	public abstract class Binop : Expr { }

	public class Add : Binop
	{
		Expr e1, e2;

		public Add(Expr e1, Expr e2)
		{
			this.e1 = e1;
			this.e2 = e2;
		}

		public override string ToString()
		{
			return $"({e1} + {e2})";
		}
	}

	public class Mul : Binop
	{
		Expr e1, e2;

		public Mul(Expr e1, Expr e2)
		{
			this.e1 = e1;
			this.e2 = e2;
		}

		public override string ToString()
		{
			return $"({e1} * {e2})";
		}
	}
	public class Sub : Binop
	{
		Expr e1, e2;

		public Sub(Expr e1, Expr e2)
		{
			this.e1 = e1;
			this.e2 = e2;
		}

		public override string ToString()
		{
			return $"({e1} - {e2})";
		}
}


}
