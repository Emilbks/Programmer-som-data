namespace Lecture_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("ToString()");
			Expr e1 = new Add(new Var("x"), new Sub(new CstI (1), new CstI (5)));
			Console.WriteLine(e1.ToString());
			Expr e2 = new Sub(new Var("x"), new Var("y"));
			Console.WriteLine(e2.ToString());
			Expr e3 = new Mul(new Var("x"), new Var("y"));
			Console.WriteLine(e3.ToString());
			Console.WriteLine("");

			Dictionary<string, int> env1 = new (), env2 = new ();
			env1.Add("x", 1);
			env1.Add("y", 2);
			env2.Add("x", 2);
			env2.Add("y", 3);

			Console.WriteLine("Eval() Env(x = 1, y = 2)");
			Console.WriteLine(e1.Eval(env1));
			Console.WriteLine(e2.Eval(env1));
			Console.WriteLine(e3.Eval(env1));
			Console.WriteLine("");

			Console.WriteLine("Eval() Env(x = 2, y = 3)");
			Console.WriteLine(e1.Eval(env2));
			Console.WriteLine(e2.Eval(env2));
			Console.WriteLine(e3.Eval(env2));
			Console.WriteLine("");

			Console.WriteLine("Simplify()");
			Console.WriteLine(e1.Simplify());
			Console.WriteLine(e1.Simplify());
			Console.WriteLine(e1.Simplify());

		}
		public abstract class Expr 
		{
			public abstract int Eval (Dictionary<string, int> env);
			public abstract string Simplify ();
		}

		public class CstI : Expr
		{
			int x;

			public CstI(int y) { x = y; }

			public override string ToString() { return $"{x}"; }
			public override int Eval (Dictionary<string, int> env) { return x ; }
			public override string Simplify () { return ToString(); }

		}

		public class Var : Expr
		{
			string v;

			public Var(string str) { v = str; }

			public override string ToString() { return v; }
			public override int Eval(Dictionary<string, int> env) { return env[v]; }
			public override string Simplify() { return ToString(); }
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

			public override string ToString() { return $"({e1} + {e2})"; }
			public override int Eval(Dictionary<string, int> env) { return e1.Eval(env) + e2.Eval(env); }
			public override string Simplify() { return ToString(); }
		}

		public class Mul : Binop
		{
			Expr e1, e2;

			public Mul(Expr e1, Expr e2)
			{
				this.e1 = e1;
				this.e2 = e2;
			}

			public override string ToString() { return $"({e1} * {e2})"; }
			public override int Eval(Dictionary<string, int> env) { return e1.Eval(env) * e2.Eval(env); }
			public override string Simplify() { return ToString(); }
		}
		public class Sub : Binop
		{
			Expr e1, e2;

			public Sub(Expr e1, Expr e2)
			{
				this.e1 = e1;
				this.e2 = e2;
			}

			public override string ToString() { return $"({e1} - {e2})"; }
			public override int Eval(Dictionary<string, int> env) { return e1.Eval(env) - e2.Eval(env); }
			public override string Simplify() { return ToString(); }
		}
    }
}
