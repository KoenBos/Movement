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
	class SpaceShip : MoverNode
	{
		// your private fields here (rotSpeed, thrustForce)
		private float rotSpeed;
		private float thrustForce;

		// constructor + call base constructor
		public SpaceShip() : base("resources/spaceship.png")
		{
			rotSpeed = (float)Math.PI; // rad/second
			thrustForce = 750f;

			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 2);
			Color = Color.YELLOW;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			WrapEdges();
		}

		// your own private method

		private void WrapEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			
			if (Position.X > scr_width)
			{
				Position.X *= 0;
			}
			if (Position.X < 0)
			{
				Position.X = scr_width;
			}
			if (Position.Y > scr_height)
			{
				Position.Y *= 0;
			}
			if (Position.Y < 0)
			{
				Position.Y = scr_height;
			}
		}

		public void RotateRight(float deltaTime)
		{
			Rotation += rotSpeed * deltaTime;
		}

		public void RotateLeft(float deltaTime)
		{
			Rotation -= rotSpeed * deltaTime;
		}

		public void Thrust()
		{
			// TODO implement
			Color = Color.ORANGE;
			Acceleration = thrustForce * new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
		}

		public void NoThrust()
		{
			Color = Color.YELLOW;
		}

	}
}
