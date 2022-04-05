using System.Numerics; // Matrix4x4
using Raylib_cs; // Raylib

namespace Movement
{
	class Core
	{
		public Core(string title)
		{
			int width = (int)Settings.ScreenSize.X;
			int height = (int)Settings.ScreenSize.Y;
			Raylib.InitWindow(width, height, title);
		}

		public bool Run(SceneNode scene)
		{
			if (Raylib.WindowShouldClose())
			{
				ResourceManager.Instance.CleanUp();
				Raylib.CloseWindow();
				return false;
			}

			// how many seconds since the last frame?
			float deltaTime = Raylib.GetFrameTime();

			// Transform all Nodes in the Scene
			scene.TransformNode(Matrix4x4.Identity);

			// draw the scene
			Raylib.BeginDrawing();
				Raylib.ClearBackground(Color.BLACK);

				// Update (and Draw) all nodes in the Scene
				UpdateNode(scene, deltaTime);

			Raylib.EndDrawing();

			return true;
		}

		// Updates and Draws all children recursively
		public void UpdateNode(Node node, float deltaTime)
		{
			// Update this or subclass
			node.Update(deltaTime);

			// Check is this is a SpriteNode. If so, Draw it.
			// This can be done more elegantly. We'll talk about this later...
			if (node.GetType().GetProperty("TextureName") != null)
			{
				SpriteNode spritenode = (SpriteNode) node; // must cast
				spritenode.Draw();
			}

			// Update all children
			for (int i=0; i<node.Children.Count; i++)
			{
				UpdateNode(node.Children[i], deltaTime);
			}
		}
	}
}
