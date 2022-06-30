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
    class BouncingBall : MoverNode
    {
        // your private fields here (add Velocity, Acceleration, addForce method)
        //private Vector2 Acceleration = new Vector2(0, 0);
        // constructor + call base constructor
        public BouncingBall() : base("resources/ball.png")
        {
            Position = new Vector2(Settings.ScreenSize.X / 6, Settings.ScreenSize.Y / 4);
            Color = Color.BLUE;
        }

        // Update is called every frame
        public override void Update(float deltaTime)
        {
            Fall(deltaTime);
            BounceEdges();
        }

        // your own private methods
        public void Fall(float deltaTime)
        {
            // TODO implement
            Position += Acceleration * deltaTime;

            Vector2 wind = new Vector2(0.5f, 0.0f);
            Vector2 gravity = new Vector2(0.0f, 0.5f);

            AddForce(wind);
            AddForce(gravity);
        }
        private void BounceEdges()
        {
            float scr_width = Settings.ScreenSize.X;
            float scr_height = Settings.ScreenSize.Y;
            float spr_width = TextureSize.X;
            float spr_heigth = TextureSize.Y;

            // TODO implement...
            if (Position.X + spr_width / 2 > scr_width)
            {
                Position.X = scr_width - spr_width / 2;
                Acceleration.X *= -1;
            }

            if (Position.X - spr_width / 2 < 0)
            {
                Position.X = 0 + spr_width / 2;
                Acceleration.X *= -1;
            }

            if (Position.Y + spr_heigth / 2 > scr_height)
            {
                Position.Y = scr_height - spr_heigth / 2;
                Acceleration.Y *= -1;
            }

            if (Position.Y - spr_heigth / 2 < 0)
            {
                Position.Y = 0 + spr_heigth / 2;
                Acceleration *= -1;
            }
        }
    }
}