using Raylib_cs;

namespace Movement
{
	enum State
	{
		Quit,
		Playing,
		Lost,
		Won
	}

	abstract class SceneNode : Node
	{
		public State State { get; set; }

		private string scenetitle;
		public string SceneTitle {
			get { return scenetitle; }
			set { scenetitle = value; }
		}

		protected SceneNode(string title) : base()
		{
			SceneTitle = title;
			State = State.Playing;
		}

		public override void Update(float deltaTime)
		{
			ShowFrameRate(deltaTime);
			ShowTitle();
		}

		private float timer = 0;
		private int framecounter = 0;
		private int showcounter = 0;
		private void ShowFrameRate(float deltaTime)
		{
			timer += deltaTime;
			framecounter++;
			if (timer > 1.0f) {
				timer = 0.0f;
				showcounter = framecounter;
				framecounter = 0;
			}

			Raylib.DrawText("fps: "+showcounter, 1150, 10, 20, Color.GREEN);
			// Raylib.DrawText("fps: "+Raylib.GetFPS(), 1150, 10, 20, Color.GREEN);
		}

		private void ShowTitle()
		{
			Raylib.DrawText(SceneTitle, 10, 10, 20, Color.WHITE);
		}
	}
}
