using System;
using Raylib_cs;

namespace Movement
{
	class Example101 : SceneNode
	{
		// private fields
		private SimpleBall ball;

		// constructor + call base constructor
		public Example101(string t) : base(t)
		{
			ball = new SimpleBall();
			AddChild(ball);
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
		}

	} // class

} // namespace
