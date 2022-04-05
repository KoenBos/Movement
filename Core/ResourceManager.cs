using System.Collections.Generic; // Dictionary
using Raylib_cs; // Raylib

namespace Movement
{
	// Singleton ResourceManager
	public sealed class ResourceManager
	{
		private static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
		private static readonly ResourceManager instance = new ResourceManager();

		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static ResourceManager()
		{
		}

		private ResourceManager()
		{
		}

		public static ResourceManager Instance
		{
			get
			{
				return instance;
			}
		}

		public Texture2D GetTexture(string path)
		{
			if (textures.ContainsKey(path))
			{
				// we already have this texture
				return textures[path];
			}
			// We need to load it from disk
			Texture2D texture = Raylib.LoadTexture(path);
			textures.Add(path, texture);
			return texture;
		}

		public void CleanUp()
		{
			foreach (var pair in textures)
			{
				Raylib.UnloadTexture(pair.Value);
			}
		}
	}
}
