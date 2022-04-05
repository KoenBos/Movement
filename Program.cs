namespace Movement
{
	class Program
	{
		static void Main(string[] args)
		{
			Game game = new Game();
			game.Play();

			// run the Vector2 tests in Tests.cs
			Tests tests = new Tests();
			tests.Run();
		}
	}
}
