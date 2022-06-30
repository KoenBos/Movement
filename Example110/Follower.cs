using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Color

/*
In this class, we have the properties:

- Vector2  Position
- float    Rotation
- Vector2  Scale

- Vector2 TextureSize
- Vector2 Pivot
- Color Color

Methods:

- AddChild(Node child)
- RemoveChild(Node child, bool keepAlive = false)
*/

namespace Movement
{
	class Follower : MoverNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)

		// constructor + call base constructor
		public Follower() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 2);
			Color = Color.GREEN;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Follow(deltaTime);
			Move(deltaTime);
		}

		// your own private methods
		private void Follow(float deltaTime)
		{
			Vector2 mouse = Raylib.GetMousePosition();
			Vector2 direction = mouse - Position;
			Vector2.Normalize(direction);
            Acceleration = direction;
            Acceleration *= 3;
		}

	}
}
