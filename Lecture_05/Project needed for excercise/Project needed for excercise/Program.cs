int[] xs = [3, 5, 12],
	  ys = [2, 3, 4, 7];

int[] t = Merge(xs, ys);

Console.Write("["); for (int i = 0; i < t.Length-1; i++) Console.Write($"{t[i]}; "); Console.WriteLine($"{t[t.Length-1]}]");




static int[] Merge(int[] xs, int[] ys)
{
	int[] list = new int[xs.Length + ys.Length];
	int px = 0, py = 0;
	for (int i = 0; i < list.Length; i++)
	{
		if (px == xs.Length) { list[px + py] = ys[py++]; continue; }
		if (py == ys.Length) { list[px + py] = xs[px++]; continue; }


		if (xs[px] <= ys[py]) list[px + py] = xs[px++];
		else if (xs[px] > ys[py]) list[px + py] = ys[py++];
	}
	return list;
}