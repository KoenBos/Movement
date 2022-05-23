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
	class AcceleratingBall : SpriteNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		Vector2 Velocity = new Vector2(200, 200);

		// constructor + call base constructor
		public AcceleratingBall() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
			Color = Color.RED;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			BounceEdges();
		}

		// your own private methods
		private void Move(float deltaTime)
		{
			// TODO implement
			// Position += Velocity * deltaTime;
			Position.X += Velocity.X * deltaTime;
			Position.Y += Velocity.Y * deltaTime;
		}

		private void BounceEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			// TODO implement...
			if (Position.X > scr_width|| Position.X < 0)
			{
				Velocity.X *= -1;
			}
			if (Position.Y > scr_height|| Position.Y < 0)
			{
				Velocity.Y *= -1;
			}
		}

	}
}
