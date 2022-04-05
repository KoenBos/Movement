using System;
using Raylib_cs;

namespace Movement
{
	class Exercise305 : SceneNode
	{
		// private fields
		private SpaceShip spaceship;

		// constructor + call base constructor
		public Exercise305(String t) : base(t)
		{
			spaceship = new SpaceShip();
			AddChild(spaceship);
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);

			HandleInput(deltaTime);
		}

		private void HandleInput(float deltaTime)
		{
			if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
				spaceship.RotateLeft(deltaTime);
			}
			if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
				spaceship.RotateRight(deltaTime);
			}
			if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) {
				spaceship.Thrust();
			}
			if (Raylib.IsKeyReleased(KeyboardKey.KEY_UP)) {
				spaceship.NoThrust();
			}
		}

	} // class

} // namespace
