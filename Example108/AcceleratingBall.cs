using System.Numerics; // Vector2
using Raylib_cs; // Color
using System;

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
		//Private fields here (add Velocity, Acceleration, and MaxSpeed)
		private Vector2 Velocity = new Vector2(100,100);
		private float  MaxSpeed = 1500;
		private Vector2 Acceleration;

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
			WrapEdges();
			Console.WriteLine(Velocity.Length());
			Velocity = Limit(Velocity, MaxSpeed);
		}

		//Private methods
	
		private void Move(float deltaTime)
		{
			// TODO implement
			Position += Velocity * deltaTime;
			Velocity += Acceleration * deltaTime;
			Acceleration = new Vector2(40, 30);
			// limit to a maximum speed of 1000 pixels/second
			
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

	}
}
