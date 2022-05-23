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
	class SimpleBall : SpriteNode
	{
		// your private fields here
		float xspeed = 200; 
		float yspeed = 200; 
		

		// constructor + call base constructor
		public SimpleBall() : base("resources/bigball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
			Color = Color.GREEN;
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
			// Position.X += 200 * deltaTime;
			Position.X += xspeed * deltaTime;
			Position.Y += yspeed * deltaTime;
		}

		private void BounceEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			// TODO implement...
			if (Position.X + spr_width / 2 > scr_width|| Position.X - spr_width /2 < 0)
			{
				xspeed *= -1;
			}
			if (Position.Y + spr_heigth /2 > scr_height|| Position.Y - spr_heigth / 2 < 0)
			{
				yspeed *= -1;
			}
		}

	}
}
