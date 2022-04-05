using System;
using System.Numerics;

namespace Movement
{
	class Tests
	{
		// private fields
		Vector2 velocity;

		// constructor
		public Tests()
		{
			velocity = new Vector2(4, 3);
		}

		public void Run()
		{
			// cartesian (x,y) to polar (magnitude, angle)
			Console.WriteLine("velocity: " + velocity);

			double magnitude = velocity.Length();
			Console.WriteLine("magnitude: " + magnitude);

			double angle = Math.Atan2(velocity.Y, velocity.X);
			Console.WriteLine("angle: " + angle + " radians");
			Console.WriteLine("angle: " + (angle * 180 / Math.PI) + " degrees");

			// normalize the velocity
			Vector2 normalized = Vector2.Normalize(velocity);
			Console.WriteLine("velocity: " + velocity);
			Console.WriteLine("normalized: " + normalized);

			// polar (magnitude, angle) to cartesian (x,y) coordinates
			double fromPolarX = Math.Cos(angle) * magnitude;
			double fromPolarY = Math.Sin(angle) * magnitude;
			Vector2 fromPolar = new Vector2((float)fromPolarX, (float)fromPolarY);
			Console.WriteLine("fromPolar: " + fromPolar);

			// limit
			float max = 2;
			Vector2 limited;
			if (magnitude < 1.0) {
				limited = velocity * max;
			} else {
				limited = normalized * max;
			}
			Console.WriteLine("limited to magnitude "+max+": " + limited);
		}

	}
}
