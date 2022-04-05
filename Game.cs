using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Movement
{
	class Game
	{
		// private fields
		private Core core;
		private List<SceneNode> scenes;

		// constructor
		public Game()
		{
			core = new Core("Movement Exercises");
			scenes = new List<SceneNode>();

			scenes.Add(new Example101("Example 1.1 - Ball without vectors"));
			scenes.Add(new Example102("Example 1.2 - Ball with vectors (velocity)"));
			scenes.Add(new Example108("Example 1.8 - Accelerating Ball (acceleration)"));
			scenes.Add(new Example110("Example 1.10 - Mouse follower"));
			scenes.Add(new Example201("Example 2.1 - Bouncing Ball with Forces (wind, gravity)"));
			scenes.Add(new Example303("Example 3.3 - Pointing in the direction of motion"));
			scenes.Add(new Exercise305("Exercise 3.5 - SpaceShip"));
			scenes.Add(new Example405("Example 4.5 - System of Particle Systems"));
		}

		// public methods
		public void Play()
		{
			int scene_id = 0;
			bool running = true;
			while (running)
			{
				// handle scene_id
				if (Raylib.IsKeyReleased(KeyboardKey.KEY_LEFT_BRACKET)) { scene_id--; }
				if (Raylib.IsKeyReleased(KeyboardKey.KEY_RIGHT_BRACKET)) { scene_id++; }
				if (scene_id <= 0) { scene_id = 0; }
				if (scene_id >= scenes.Count) { scene_id = scenes.Count-1; }

				// run current scene
				SceneNode current = scenes[scene_id];
				running = core.Run(current);
			}

			Console.WriteLine("Thank you for playing!");
		}
	}
}
