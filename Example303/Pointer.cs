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
	class Pointer : MoverNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		private float  MaxSpeed = 500;

		// constructor + call base constructor
		public Pointer() : base("resources/spaceship.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 2);
			Color = Color.YELLOW;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			PointToMouse(deltaTime);
			Follow(deltaTime);
			Move(deltaTime);
			Velocity = Limit(Velocity, MaxSpeed);
		}

		// your own private methods
		private void PointToMouse(float deltaTime)
		{
			Rotation = (float)Math.Atan2(Velocity.Y, Velocity.X);
		}

		private void Follow(float deltaTime)
		{
			Vector2 mouse = Raylib.GetMousePosition();
			Vector2 direction = mouse - Position;
			Vector2.Normalize(direction);
            Acceleration = direction;
            Acceleration *= 10;
		}
		private Vector2 Limit(Vector2 v, float max)
        {
            Vector2 limited = v;

            if (v.Length() > max)
            {
                limited = Vector2.Normalize(v);
                limited = limited * max;
            }

            return limited;
        }

		private void BounceEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			// TODO implement...
			if (Position.X > scr_width)
			{
				// ...
			}
		}

	}
}
